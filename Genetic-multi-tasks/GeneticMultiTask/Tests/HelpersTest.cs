using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Entities;
using Shared.Helpers;

namespace Tests
{
    [TestClass]
    public class HelpersTest
    {
        [TestMethod]
        public void IntegrityHelperTestTrue()
        {
            Candidate cand1 = new Candidate();
            Candidate cand2 = new Candidate();
            List<Candidate> list = new List<Candidate>();
            list.Add(cand1);
            list.Add(cand2);
            Assert.IsTrue(IntegrityHelper.checkCandidateDuplicates(list));
        }

        [TestMethod]
        public void IntegrityHelperTestFalse()
        {
            Candidate cand1 = new Candidate();
            Candidate cand2 = cand1;
            List<Candidate> list = new List<Candidate>();
            list.Add(cand1);
            list.Add(cand2);
            Assert.IsFalse(IntegrityHelper.checkCandidateDuplicates(list));
        }
    }
}
