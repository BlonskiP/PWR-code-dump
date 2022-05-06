using Shared.AbstractClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Candidate
    {
        public List<int> chromoson;
        public int generation = 0;
        public float fitness;
        public GeneticSolver solver;
        public string time;
        public Candidate() { }
        public Candidate(Candidate cand)
        {
            this.time = cand.time;
            this.generation = cand.generation;
            this.solver = cand.solver;
            this.chromoson = new List<int>(cand.chromoson);
            this.CountFitness();
        }
        public Candidate(int generation, List<int> genotype, GeneticSolver solver, string time)
        {
            this.time = time;
            this.generation = generation;
            this.solver = solver;
            chromoson = genotype;
            CountFitness();
        }
        public void CountFitness() {
            fitness = solver.matrix.countCost(chromoson);
        }

    }
}
