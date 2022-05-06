using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AbstractClasses
{
    public abstract class CrossoverType
    {
        public string CrossoverName;
        public float CrossoverChance;
        public abstract List<Candidate> Crossover(Candidate parentX, Candidate parentY);

        public abstract List<Candidate> CrossoverPopulation(List<Candidate> population, int populationSize);
    }
}
