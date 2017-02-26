using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dnp.Kanban.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Dnp.Kanban.Domain.Tests
{
    [TestClass()]
    public class ProjectServiceTests
    {
        [TestInitialize]
        public void Setup()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod()]
        [ExpectedException(typeof( InvalidOperationException))]
        public void SaveStageWithExistingNameFailTest()
        {
            Mock<IProjectRepository> repositoryMock = new Mock<IProjectRepository>();
            repositoryMock.Setup(r => r.GetProjectStages(1)).Returns(() =>
           {
               return new List<ProjectStage> { new ProjectStage {  ID = 1, ProjectID = 1, StageName ="Back Log"},
                                                new ProjectStage {  ID = 2, ProjectID = 1, StageName ="In Progress"},
                                                new ProjectStage {  ID = 3, ProjectID = 1, StageName ="Completed"}
                                               };
           });

            ProjectStage stageMock = new ProjectStage { ProjectID = 1, StageName = "Back Log" };

            repositoryMock.Setup(r => r.SaveStage(stageMock)).ReturnsAsync(5);

            ProjectService service = new ProjectService(repositoryMock.Object);

            service.SaveStage(stageMock);

            
        }

        [TestMethod]
        public void SaveStageWithNewNameTest()
        {
            Mock<IProjectRepository> repositoryMock = new Mock<IProjectRepository>();
            repositoryMock.Setup(r => r.GetProjectStages(1)).Returns(() =>
            {
                return new List<ProjectStage> { new ProjectStage {  ID = 1, ProjectID = 1, StageName ="Back Log"},
                                                new ProjectStage {  ID = 2, ProjectID = 1, StageName ="In Progress"},
                                                new ProjectStage {  ID = 3, ProjectID = 1, StageName ="Completed"}
                                               };
            });

            ProjectStage stageMock = new ProjectStage { ProjectID = 1, StageName = "Done" };

            repositoryMock.Setup(r => r.SaveStage(stageMock)).ReturnsAsync(4);

            ProjectService service = new ProjectService(repositoryMock.Object);

            int newValue = service.SaveStage(stageMock).Result ;

            Assert.IsTrue(newValue > 0, "New Stage save is failed");

        }
    }
}