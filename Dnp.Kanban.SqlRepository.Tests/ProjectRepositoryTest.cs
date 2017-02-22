using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dnp.Kanban.Domain;
using FizzWare.NBuilder;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.Generic;
using System.Linq;

namespace Dnp.Kanban.SqlRepository.Tests
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        IProjectRepository _projRepository;
        

        [TestInitialize]
        public void Setup()
        {
            MapperSetup.InitializeMapper();
            _projRepository = new SqlProjectRepository("DefaultConnection");
            
        }

        [TestMethod]
        public async Task SaveProjectTest()
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Project testProj = Builder<Project>.CreateNew().With(p => p.ID = 0).Build();
                int projectId = await _projRepository.SaveProject(testProj);
                Assert.AreNotEqual(0, projectId, "Creating new Project doesn't return ID");

                List<ProjectStage> stages = _projRepository.GetProjectStages(projectId);

                Assert.AreEqual(3, stages.Count, "Default Project Stages not created.");

                Assert.IsTrue(stages.Any(s => s.StageName == "Back Log"), "Default Stage \"Back Log\" not created");
                Assert.IsTrue(stages.Any(s => s.StageName == "In Progress"), "Default Stage \"In Progress\" not created");
                Assert.IsTrue(stages.Any(s => s.StageName == "Completed"), "Default Stage \"Completed\" not created");
            }
        }
    }
}
