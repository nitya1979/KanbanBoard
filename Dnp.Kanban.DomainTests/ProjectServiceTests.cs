using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Dnp.Kanban.Domain.Tests
{
    [TestFixture]
    public class ProjectServiceTests
    {
        Mock<IProjectRepository> mockRepository;

        [SetUp]
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

        [Test]
        public void SaveStageWithExistingNameFailTest()
        {

            ProjectStage stageMock = new ProjectStage { ProjectID = 1, StageName = "Back Log" };

            mockRepository.Setup(r => r.SaveStage(stageMock)).ReturnsAsync(5);

            ProjectService service = new ProjectService(mockRepository.Object);

            TestDelegate testDel = ()=> { service.SaveStage(stageMock); };

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(  testDel);

            Assert.AreEqual(string.Format("Stage '{0}' already exists", stageMock.StageName), exception.Message, "Not sent correct message");


        }

        [Test]
        public void SaveStageWithNewNameTest()
        {

            ProjectStage stageMock = new ProjectStage { ProjectID = 1, StageName = "Done" };

            mockRepository.Setup(r => r.SaveStage(stageMock)).ReturnsAsync(4);

            ProjectService service = new ProjectService(mockRepository.Object);

            int newValue = service.SaveStage(stageMock).Result;

            Assert.IsTrue(newValue > 0, "New Stage save is failed");

        }

        [Test]
        public void SaveStageWithProjectIdZeroFailTest()
        {
            ProjectStage mockStage = new ProjectStage { StageName = "New Stage" };

            mockRepository.Setup(r => r.SaveStage(mockStage)).ReturnsAsync(4);

            ProjectService service = new ProjectService(mockRepository.Object);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => { service.SaveStage(mockStage); });

            Assert.AreEqual("Project ID must be defined.", exception.Message, "Incorrect message for error");

            
        }
    }
}