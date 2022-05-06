using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MultiTask.Mutation;
using Shared.Entities;
using Shared.Helpers;
using SingleTask.Solver;

namespace Tests
{
    [TestClass]
    public class MultiThreadTests
    {
        MultiTaskGeneticSolver solver;
        AdjacencyMatrix matrix;
        [TestMethod]
        public void PMXmultiThread()
        {
            String FileName = "C:\\Studia\\Genetic-multi-tasks\\GeneticMultiTask\\TSP instances\\br17.xml";
            XDocument tspXmlFile = XDocument.Load(FileName);
            AdjacencyMatrix matrix = new AdjacencyMatrix(tspXmlFile);
            MultiThreadInversionMutation pmx = new MultiThreadInversionMutation(1);
            MultiTaskGeneticSolver solver = new MultiTaskGeneticSolver(matrix, pmx, null, null, 100,0);
            List<Candidate> population = randomPopulation(50);

            pmx.MutateList(population);

        }

        public Candidate randomCandidate() //only 1st generation
        {

            List<int> chromosone = new List<int>();
            List<int> verticles = new List<int>();
            for (int i = 1; i < matrix.CostMatrix.GetLength(0); i++)
            {
                verticles.Add(i);
            }
            while (verticles.Count != 0)
            {

                int verticle = RandomHelper.Next() % verticles.Count();//random verticle
                chromosone.Add(verticles[verticle]);
                verticles.RemoveAt(verticle);
            }
            Candidate newCandidate = new Candidate(1, chromosone, null, "test");
            return newCandidate;
        }

        public  List<Candidate> randomPopulation(int size)
        {
            List<Candidate> population = new List<Candidate>();
            for (int i = 0; i < size; i++)
            {
                population.Add(randomCandidate());
            }
            return population;
        }
    }
}
