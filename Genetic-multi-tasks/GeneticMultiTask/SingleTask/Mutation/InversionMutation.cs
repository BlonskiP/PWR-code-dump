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
    public class InversionMutation : MutationType
    {
       
        public InversionMutation(float mutationChance)
        {
            this.mutationChance = mutationChance;
            this.MutationName = "InversionMutation";
        }
        public override Candidate Mutate(Candidate candidate)
        {
            double chance = RandomMutator.NextDouble();
            Candidate mutant = new Candidate(candidate);
            if(chance<mutationChance)
            {
                int endIndex;
                int startIndex = RandomMutator.Next(0, candidate.chromoson.Count());
                do
                {
                    endIndex = RandomMutator.Next(0, candidate.chromoson.Count());
                } while (startIndex == endIndex);
                if(startIndex>endIndex)
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
            List<Candidate> mutants = new List<Candidate>();
            foreach(var candidate in population)
            {
                mutants.Add(Mutate(candidate));
            }
            return population;
        }
    }
}
