using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AbstractClasses
{
    abstract public class MutationType
    {
        public string MutationName;
        public float mutationChance;
        public abstract Candidate Mutate(Candidate candidate);
        public abstract List<Candidate> MutateList(List<Candidate> population);
    }
}
