using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dnp.Kanban.SqlRepository.Tests
{
    [TestClass]
    public class ProjectMappingTest
    {
        [TestMethod]
        public void TestProjectMapping()
        {
            MapperSetup.InitializeMapper();
        }
    }
}
