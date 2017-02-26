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
    [Test]
    public class ProjectServiceTests
    {
        Mock<IProjectRepository> mockRepository;

        [TestInitialize]
        public void Setup()
        {
            mockRepository = new Mock<IProjectRepository>();

            mockRepository.Setup(r => r.GetProjectStages(1)).Returns(() =>
            {
                return new List<ProjectStage> { new ProjectStage {  ID = 1, ProjectID = 1, StageName ="Back Log"},
                                                new ProjectStage {  ID = 2, ProjectID = 1, StageName ="In Progress"},
                                                new ProjectStage {  ID = 3, ProjectID = 1, StageName ="Completed"}
                                                };
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            
        }

        [TestMethod]
        [ExpectedException(typeof( InvalidOperationException))]
        public void SaveStageWithExistingNameFailTest()
        {

            ProjectStage stageMock = new ProjectStage { ProjectID = 1, StageName = "Back Log" };

            mockRepository.Setup(r => r.SaveStage(stageMock)).ReturnsAsync(5);

            ProjectService service = new ProjectService(mockRepository.Object);

            service.SaveStage(stageMock);

            
        }

        [TestMethod]
        public void SaveStageWithNewNameTest()
        {

            ProjectStage stageMock = new ProjectStage { ProjectID = 1, StageName = "Done" };

            mockRepository.Setup(r => r.SaveStage(stageMock)).ReturnsAsync(4);

            ProjectService service = new ProjectService(mockRepository.Object);

            int newValue = service.SaveStage(stageMock).Result ;

            Assert.IsTrue(newValue > 0, "New Stage save is failed");

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SaveStageWithProjectIdZeroFailTest()
        {
            ProjectStage mockStage = new ProjectStage { StageName = "New Stage" };

            mockRepository.Setup(r => r.SaveStage(mockStage)).ReturnsAsync(4);

            ProjectService service = new ProjectService(mockRepository.Object);

            int newValue = service.SaveStage(mockStage).Result;

            AssertThrows
        }
    }
}