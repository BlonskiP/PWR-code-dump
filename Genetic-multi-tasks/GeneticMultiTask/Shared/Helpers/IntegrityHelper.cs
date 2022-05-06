using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    static public class IntegrityHelper
    {
        static public bool checkGens(Candidate candidate)
        {
              
          if (candidate.chromoson.Contains(0))
          {
            return false;
          }
          if (candidate.chromoson.Count != candidate.chromoson.Distinct().Count())
          {
            return false;
          }

            return true;
        }

        static public bool checkGens(List<Candidate> candidates)
        {
            foreach(var candidate in candidates)
            {
                if(checkGens(candidate)==false)
                {
                    return false;
                }
            }
            return true;
        }

        static public bool checkCandidateDuplicates(List<Candidate> candidates)
        {
            List<Candidate> cand = candidates.Distinct().ToList();
            if(candidates.Count != cand.Count())
            {
                return false;
            }
            return true;
        }
    }
}
