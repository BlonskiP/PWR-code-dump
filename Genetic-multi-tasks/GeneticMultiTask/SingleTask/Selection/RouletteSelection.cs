using Shared.AbstractClasses;
using Shared.Entities;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTask.Mutation
{
    public class RouletteSelection : SelectionType
    {
        List<Candidate> BreedingPool;
        public RouletteSelection(int size)
        {
            this.selectionSize = size;
            BreedingPool = new List<Candidate>();
            this.SelectionName = "RouletteSelection";


        }
        public override List<Candidate> generateBreedingPool(List<Candidate> candList)
        {
            BreedingPool = new List<Candidate>();
            double FittnesSum = countAllFittnes(candList);
            List<RouletteResult> results = CreateResultsList(candList, FittnesSum);
            fillBreedingPool(results);
            return BreedingPool;
            
        }

        private void fillBreedingPool(List<RouletteResult> results)
        {
            var TempBreedingPool = new List<Candidate>();
            double randomRouletteNumber;
            for(int i=0;i<selectionSize;i++)
            {
                randomRouletteNumber = RandomSelector.NextDouble();
                Candidate temp = FindCandidate(results, randomRouletteNumber);
                if (temp != null)
                    TempBreedingPool.Add(temp);
                else
                    i--;
            }
            BreedingPool = TempBreedingPool.ToList();
        }
        private Candidate FindCandidate(List<RouletteResult> results, double randomNumber)
        {
            Candidate temp;
            foreach(var result in results)
            {
                if(randomNumber>result.from && randomNumber<=result.to)
                {
                    results.Remove(result);
                    return result.cand;
                }
            }
        return null;
        }
        private List<RouletteResult> CreateResultsList(List<Candidate> candList, double fittnesSum)
        {
            List<RouletteResult> rouletteResults = new List<RouletteResult>();
            double probability = 0;
            double p2 = 0;
            foreach(var candidate in candList)
            {
                probability = (1/candidate.fitness) / fittnesSum;
                RouletteResult result = new RouletteResult(p2,probability,candidate);
                p2 += probability;
                rouletteResults.Add(result);
            }
            return rouletteResults;
        }

        private double countAllFittnes(List<Candidate> candList)
        {
            double FittnesSum = 0;
            foreach(var candidate in candList)
            {
                FittnesSum += 1/candidate.fitness;
            }
            return FittnesSum;
        }
        struct RouletteResult
        {
            public Candidate cand;
            public double from;
            public double to;
            

            public RouletteResult(double probability, double p2,Candidate cand) : this()
            {
                this.from = probability;
                this.to = probability + p2;
                this.cand = cand;
            }
        }
    
    }
}
