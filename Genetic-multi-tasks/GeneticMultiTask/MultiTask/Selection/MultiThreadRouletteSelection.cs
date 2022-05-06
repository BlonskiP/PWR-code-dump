using Shared.AbstractClasses;
using Shared.Entities;
using Shared.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTask.Selection
{
    public class MultiThreadRouletteSelection : SelectionType
    {
        List<Candidate> BreedingPool;
        public MultiThreadRouletteSelection(int size)
        {
            this.selectionSize = size;
            BreedingPool = new List<Candidate>();
            this.SelectionName = "MultiThreadRouletteSelection";
        }
        public override List<Candidate> generateBreedingPool(List<Candidate> candList)
        {
            BreedingPool = new List<Candidate>();
            
            double FittnesSum = countAllFittnes(candList);
            ConcurrentQueue<RouletteResult> results = CreateResultsList(candList, FittnesSum);
            fillBreedingPool(results);
            return BreedingPool;
            
        }

        private void fillBreedingPool(ConcurrentQueue<RouletteResult> results)
        {
            var TempBreeginPool = new ConcurrentQueue<Candidate>();
            
            Parallel.For(0, selectionSize, i => {
                double randomRouletteNumber;
                randomRouletteNumber = RandomSelector.NextDouble();
                Candidate temp = FindCandidate(results, randomRouletteNumber);
                if (temp != null)
                    TempBreeginPool.Enqueue(temp);

            });
            BreedingPool = TempBreeginPool.ToList();
        }
        private Candidate FindCandidate(ConcurrentQueue<RouletteResult> results, double randomNumber)
        {
            foreach(var result in results)
            {
                if(randomNumber>result.from && randomNumber<=result.to)
                {
                    return result.cand;
                }
            }
        return null;
        }
        private ConcurrentQueue<RouletteResult> CreateResultsList(List<Candidate> candList, double fittnesSum)
        {
            ConcurrentQueue<RouletteResult> rouletteResults = new ConcurrentQueue<RouletteResult>();
            double probability = 0;
            double p2 = 0;
            Parallel.ForEach(candList, candidate =>
            {
                probability = (1 / candidate.fitness) / fittnesSum;
                RouletteResult result = new RouletteResult(p2, probability, candidate);
                p2 += probability;
                rouletteResults.Enqueue(result);
            });
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
