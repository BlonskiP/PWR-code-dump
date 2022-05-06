//https://www.iwr.uni-heidelberg.de/groups/comopt/software/TSPLIB95/STSP.html
using Shared.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Entities;
using Shared.AbstractClasses;
using Shared.Helpers;

namespace SingleTask.Solver
{
    public class MultiTaskGeneticSolver : GeneticSolver
    {
        public MultiTaskGeneticSolver(AdjacencyMatrix matrix, MutationType mutation, CrossoverType crossover, SelectionType selectionType, int populationSize, int MaxTime)
        {
            this.SolverTitle = "Multi Thread Solver";
            this.crossover = crossover;
            this.matrix = matrix;
            this.mutation = mutation;
            maxPopulationSize = populationSize;
            selector = selectionType;
            rnd = new Random();
            this.MaxTime = MaxTime;
            results = new List<Candidate>();
            time = new Stopwatch();
            bestPerTwoMinutes = new List<Candidate>();
            result = new Result(this);
            minutes= 0;
        }
        public MultiTaskGeneticSolver() {
            MaxTime = 10;
        }//for tests only
        public override Result Solve()
        {
           
            List<Candidate> breedingPool;
            List<Candidate> newPopulation;
            List<Candidate> mutants = new List<Candidate>();
            population = randomPopulation(); //create random population
            //checkGens(population);  //DEBUG ONLY
            bestCandidate = population[0];

            while (time.ElapsedMilliseconds < MaxTime * 1000)
            {


                findBest(population);
                time.Start();
                breedingPool = selector.generateBreedingPool(population);
                newPopulation = crossover.CrossoverPopulation(breedingPool,maxPopulationSize);
                time.Stop();
                findBest(population);
                time.Start();
                mutants = mutation.MutateList(newPopulation);
                population = mutants;
                time.Stop();
            }


            bestPerTwoMinutes.Add(findBest(population));
            result.time = (time.ElapsedMilliseconds / 1000).ToString();
            result.results = results;
            result.bestResult = bestCandidate;
            Console.WriteLine("INFO FROM" + result.measureName);
            Console.WriteLine("Genetic algorithm ended: Best candidate= " + bestCandidate.fitness + " TIME: " +time.ElapsedMilliseconds +"Time on result:" +result.time);
            return result;
        }

        public override Candidate randomCandidate() //only 1st generation
        {
            
            List<int> chromosone = new List<int>();
            List<int> verticles = new List<int>();
            for(int i=1;i<matrix.CostMatrix.GetLength(0);i++)
            {
                verticles.Add(i);
            }
            while(verticles.Count!=0)
            {
               
                int verticle = rnd.Next()%verticles.Count();//random verticle
                chromosone.Add(verticles[verticle]);
                verticles.RemoveAt(verticle);
            }
            Candidate newCandidate = new Candidate(1,chromosone, this,time.ElapsedMilliseconds.ToString());
            return newCandidate;
        }
        public override List<Candidate> randomPopulation()
        {
            List<Candidate> population = new List<Candidate>();
            for(int i=0;i<maxPopulationSize;i++)
            {
                population.Add(randomCandidate());
            }
            return population;
        }

        public override Candidate findBest(List<Candidate> population)
        {
            Candidate best = population[0];
            float bestScore = float.MaxValue;
            foreach(var candidate in population)
            {
                if(bestScore>candidate.fitness)
                {
                    bestScore = candidate.fitness;
                    best = candidate;
                }
            }
            if(best.fitness<bestCandidate.fitness)
            {
                bestCandidate = best;
               
                results.Add(bestCandidate);
               
            }
            return best;
        }
        protected override bool checkGens(List<Candidate> candidates)
        {
            foreach(var candidate in candidates)
            {
                if(candidate.chromoson.Contains(0))
                {
                    return false;
                }
            }
            return true;
        }

        protected override void getNextBestTwoMinutesCandidate(List<Candidate> population)
        {
            long timePassed = time.ElapsedMilliseconds/1000;
            if((timePassed)>=minutes)
            {
                bestPerTwoMinutes.Add(findBest(population));
                minutes = minutes + 120;
            }
        }
        
    }
}
