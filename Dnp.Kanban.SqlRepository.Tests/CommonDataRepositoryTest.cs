using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dnp.Kanban.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Dnp.Kanban.SqlRepository.Tests
{
    [TestClass]
    public class CommonDataRepositoryTest
    {
        ICommonDataRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            MapperSetup.InitializeMapper();
            _repository = new SqlCommonDataRepository("DefaultConnection");

        }

        [TestMethod]
        public async Task GetPropertiesCountTest()
        {
            List<DnpPriority> _priorities = await _repository.GetPriorities();

            Assert.AreEqual(4, _priorities.Count, "Number of priority is not matching.");
        }

        [TestMethod]
        public async Task GetPrioritiesValueTest()
        {
            List<DnpPriority> _priorities = await _repository.GetPriorities();

            Assert.IsTrue(_priorities.Any(p => p.Name.Equals("Critical")), "Priority 'Critical' is missing from the list.");
            Assert.IsTrue(_priorities.Any(p => p.Name.Equals("High")), "Priority 'High' is missing from the list.");
            Assert.IsTrue(_priorities.Any(p => p.Name.Equals("Medium")), "Priority 'Medium' is missing from the list.");
            Assert.IsTrue(_priorities.Any(p => p.Name.Equals("Low")), "Priority 'Low' is missing from the list.");

        }
    }
}
