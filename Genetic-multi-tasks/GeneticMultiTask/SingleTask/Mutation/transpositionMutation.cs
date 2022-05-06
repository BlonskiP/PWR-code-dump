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
    public class TranspositionMutation : MutationType
    {
        public TranspositionMutation(float mutationChance)
        {
            this.mutationChance = mutationChance;
            this.MutationName = "TranspositionMutation";
        }
        public override Candidate Mutate(Candidate candidate)
        {
            double chance = RandomMutator.NextDouble();
            if(chance<mutationChance)
            {
                int index1 = RandomMutator.Next(0, candidate.chromoson.Count());
                int index2;
                do
                {
                    index2 = RandomMutator.Next(0, candidate.chromoson.Count());
                } while (index1 == index2);
                Swap<int>(candidate.chromoson, index1, index2);

            }
            return candidate;

        }
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        public override List<Candidate> MutateList(List<Candidate> population)
        {
            foreach (var candidate in population)
            {
                Mutate(candidate);
            }
            return population;
        }
    }
}
