using Shared.AbstractClasses;
using Shared.Entities;
using Shared.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTask.Selection
{
    public class MultiThreadTournamentSelection : SelectionType
    {
        public int TournamentSize;
        List<Candidate> BreedingPool;

        public MultiThreadTournamentSelection(int size)
        {
            TournamentSize = size;
            this.selectionSize = size;
            BreedingPool = new List<Candidate>();
            this.SelectionName = "MultiThreadTournamentSelection";
        }
        public override List<Candidate> generateBreedingPool(List<Candidate> candList)
        {
            BreedingPool = new List<Candidate>();
            Candidate winner;
            ConcurrentQueue<Candidate> winnerList = new ConcurrentQueue<Candidate>();
            int size = (int)(candList.Count() * 0.3);
            while (BreedingPool.Count() <size)
            {
                Parallel.For(0, TournamentSize, i=> {
                    ConcurrentQueue<Candidate> participants = getRandomCandidates(candList);
                    winner = Tournament(participants);
                    winnerList.Enqueue(winner);
                });
                winner = Tournament(winnerList);
                winnerList = new ConcurrentQueue<Candidate>();
                candList.Remove(winner);
                    BreedingPool.Add(winner);
            }
            BreedingPool.OrderBy(o => o.fitness);
            return BreedingPool;
        }
        private ConcurrentQueue<Candidate> getRandomCandidates(List<Candidate> candList)
        {
            ConcurrentQueue<Candidate> participants = new ConcurrentQueue<Candidate>();
            Parallel.For(0, TournamentSize, i => {
                int index = RandomSelector.Next(0, candList.Count() - 1);
                participants.Enqueue(candList[index]);
            });

            return participants;
        }
        private Candidate Tournament(ConcurrentQueue<Candidate> participants)
        { 
            return participants.OrderBy(cand => cand.fitness).First();
        }
    }
}
