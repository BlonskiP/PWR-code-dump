using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.AbstractClasses
{
    public abstract class SelectionType
    {
        public string SelectionName;
        public int selectionSize;
        public abstract List<Candidate> generateBreedingPool(List<Candidate> candList);
    }
}
