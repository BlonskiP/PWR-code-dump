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
    public class TournamentSelection : SelectionType
    {
        public int TournamentSize;
        List<Candidate> BreedingPool;

        public TournamentSelection(int size)
        {
            TournamentSize = size;
            this.selectionSize = size;
            BreedingPool = new List<Candidate>();
            this.SelectionName = "TournamentSelection";
        }
        public override List<Candidate> generateBreedingPool(List<Candidate> candList)
        {
            BreedingPool = new List<Candidate>();
            Candidate winner;
            List<Candidate> winnerList = new List<Candidate>();
            int size = (int)(candList.Count() * 0.3);
            while (BreedingPool.Count() <size)
            {
                
                while (winnerList.Count() <= TournamentSize)
                {
                    List<Candidate> participants = getRandomCandidates(candList);
                    winner = Tournament(participants);
                    winnerList.Add(winner);
                }
                winner = Tournament(winnerList);
                winnerList = new List<Candidate>();
                candList.Remove(winner);
                BreedingPool.Add(winner);
            }
            BreedingPool.OrderBy(o => o.fitness);
            return BreedingPool;
        }
        private List<Candidate> getRandomCandidates(List<Candidate> candList)
        {
            
            List<Candidate> participants = new List<Candidate>();
            for(int i=0;i<TournamentSize;i++)
            {
               
                int index = RandomSelector.Next(0, candList.Count()-1);
                participants.Add(candList[index]);
            }
            return participants;
        }
        private Candidate Tournament(List<Candidate> participants)
        {
            return participants.OrderBy(cand => cand.fitness).First();
        }
    }
}
