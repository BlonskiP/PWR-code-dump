using Shared.AbstractClasses;
using Shared.Entities;
using Shared.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTask.Crossover
{
    public class MultiThreadOXCrossover : CrossoverType
    {
        public MultiThreadOXCrossover(float crossoverChance)
        {
            this.CrossoverName = "OXCrossover";
            this.CrossoverChance = crossoverChance;
        }
        public override List<Candidate> Crossover(Candidate parentX, Candidate parentY)
        {
            List<Candidate> childrenList = new List<Candidate>();
            float chance = (float)RandomCrossover.NextDouble();
            if(chance<CrossoverChance)
            {

                int startIndex = RandomCrossover.Next(0, parentX.chromoson.Count() - 1);
                int endIndex = RandomCrossover.Next(0, parentX.chromoson.Count() - 1);
                if (startIndex > endIndex)
                {
                    int temp = startIndex;
                    startIndex = endIndex;
                    endIndex = temp;
                }
                int[] childXChromosome = new int[parentX.chromoson.Count()];
                int[] childYChromosome = new int[parentX.chromoson.Count()];
                int[] parentYSection = new int[endIndex - startIndex];
                int[] parentXSection = new int[endIndex - startIndex];

                fillParentSection(ref parentXSection, parentX.chromoson, startIndex, endIndex);
                fillParentSection(ref parentYSection, parentY.chromoson, startIndex, endIndex);
                FillChromosoneWithParenScetion(ref childXChromosome, parentYSection, startIndex);
                FillChromosoneWithParenScetion(ref childYChromosome, parentXSection, startIndex);

                FillChromosoneWithMissingGens(ref childXChromosome, parentX.chromoson, endIndex);
                FillChromosoneWithMissingGens(ref childYChromosome, parentY.chromoson, endIndex);

                Candidate childX = new Candidate(parentX.generation+1, childXChromosome.ToList(), parentX.solver, parentX.solver.time.ElapsedMilliseconds.ToString());
                Candidate childY = new Candidate(parentY.generation+1, childYChromosome.ToList(), parentY.solver, parentY.solver.time.ElapsedMilliseconds.ToString());


                childrenList.Add(childX);
                childrenList.Add(childY);
                IntegrityHelper.checkGens(childrenList);

            }
            else
            {
                Candidate childX = new Candidate(parentX.generation, parentX.chromoson, parentX.solver, parentX.solver.time.ElapsedMilliseconds.ToString());
                Candidate childY = new Candidate(parentY.generation, parentY.chromoson, parentY.solver, parentY.solver.time.ElapsedMilliseconds.ToString());
                childX.generation = (parentX.generation + 1);
                childY.generation = (parentY.generation + 1);
                childrenList.Add(childX);
                childrenList.Add(childY);
                IntegrityHelper.checkGens(childrenList);
            }
            return childrenList;
        }

        

        private void FillChromosoneWithMissingGens(ref int[] childChromosome, List<int> chromoson, int endIndex)
        {
            int index = endIndex;
           for(int i=index; ;i++)
           {
                if (!childChromosome.Contains(0)) break;
                if (i >= chromoson.Count()) i = 0;
                if(!childChromosome.Contains(chromoson[i]) && childChromosome[index]==0)
                {
                    childChromosome[index] = chromoson[i];
                    index++;
                    if (index >= childChromosome.Length) index = 0;
                }
                
           }

        }

        private void FillChromosoneWithParenScetion(ref int[] childChromosome, int[] parentSection, int startIndex)
        {
           for(int i=startIndex;i<startIndex+parentSection.Length;i++)
            {
                childChromosome[i] = parentSection[i-startIndex];
            }
        }

        private void fillParentSection(ref int[] parentSection, List<int> chromoson, int startIndex, int endIndex)
        {
            for(int i=0;i<endIndex-startIndex;i++)
            {
                parentSection[i] = chromoson[startIndex + i];
            }
            
        }

        private void FillChromosone(ref int[] childYChromosome, int startIndex, int v)
        {
           
        }

        public override List<Candidate> CrossoverPopulation(List<Candidate> population, int populationSize)
        {
            int parentX;
            int parentY;
            ConcurrentQueue<Candidate> newPopulation = new ConcurrentQueue<Candidate>();
            int size = populationSize / 2;
            var res = Parallel.For(0, size,MultiTaskOptions.parallelOptCrossover, i =>
              {
                  parentX = RandomCrossover.Next(0, population.Count());
                  parentY = RandomCrossover.Next(0, population.Count());
                  var children = Crossover(population[parentX], population[parentY]);
                  newPopulation.Enqueue(children[0]);
                  newPopulation.Enqueue(children[1]);
              }) ;
                while (!res.IsCompleted) { }

            return newPopulation.ToList();
        }
    }
}
