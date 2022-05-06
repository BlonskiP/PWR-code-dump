
using Shared.AbstractClasses;
using Shared.Entities;
using Shared.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTask.Mutation
{
    public class MultiThreadInversionMutation : MutationType
    {
        public MultiThreadInversionMutation(float mutationChance)
        {
            this.mutationChance = mutationChance;
            this.MutationName = "MultiThreadInversionMutation";
   
        }
        public override Candidate Mutate(Candidate candidate)
        {
            double chance = RandomMutator.NextDouble();
            Candidate mutant = new Candidate(candidate);
            if (chance < mutationChance)
            {
                int endIndex;
                int startIndex = RandomMutator.Next(0, mutant.chromoson.Count());
                do
                {
                    endIndex = RandomMutator.Next(0, mutant.chromoson.Count());
                } while (startIndex == endIndex);
                if (startIndex > endIndex)
                {
                    int temp = startIndex;
                    startIndex = endIndex;
                    endIndex = temp;
                }
                mutant.chromoson.Reverse(startIndex, endIndex - startIndex);
            }
            mutant.CountFitness();
            return mutant;
        }

        public override List<Candidate> MutateList(List<Candidate> population)
        {
            ConcurrentQueue<Candidate> mutants = new ConcurrentQueue<Candidate>();
            var res = Parallel.ForEach(population.Distinct(), MultiTaskOptions.parallelOptMutation, candidate =>
            {
                    mutants.Enqueue(Mutate(candidate));
            });
            return population;
        }
    }
}

