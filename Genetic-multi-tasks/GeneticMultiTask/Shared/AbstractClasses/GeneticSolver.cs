using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AbstractClasses
{
    abstract public class GeneticSolver
    {
        public CrossoverType crossover;
        public MutationType mutation;
        public SelectionType selector;
        public AdjacencyMatrix matrix;

        public int maxPopulationSize;
        public int MaxTime;
        public int minutes;

        public Stopwatch time;
        public Random rnd;
        public string SolverTitle;
        public Result result;
        public Candidate bestCandidate;
        public List<Candidate> results;
        public List<Candidate> population;
        public List<Candidate> bestPerTwoMinutes;




        public abstract Result Solve();
        public abstract Candidate randomCandidate();
        public abstract Candidate findBest(List<Candidate> population);
        public abstract List<Candidate> randomPopulation();
        protected abstract bool checkGens(List<Candidate> candidates);
        protected abstract void getNextBestTwoMinutesCandidate(List<Candidate> population);
    }
}
