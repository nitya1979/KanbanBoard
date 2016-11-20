using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dnp.Kanban.Domain;
using System.Transactions;
using FizzWare.NBuilder;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dnp.Kanban.SqlRepository.Tests
{
    [TestClass]
    public class TaskRepositoryTest
    {
        ITaskRepository _repository;
        IProjectRepository _projRepository;
        TransactionScope scope;
        Project testProject;
        List<ProjectStage> stages;
        DnpTask testTask = null;

        [TestInitialize]
        public void Setup()
        {
            MapperSetup.InitializeMapper();

            _repository = new SqlTaskRepository("DefaultConnection");
            _projRepository = new SqlProjectRepository("DefaultConnection");

            scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            testProject = Builder<Project>.CreateNew().With(p => p.ID = 0).Build();
            int projectId = _projRepository.SaveProject(testProject).Result;

            testProject.ID = projectId;
            stages = _projRepository.GetProjectStages(projectId);

        }

        [TestCleanup]
        public void Cleanup()
        {
            scope.Dispose();

        }

        [TestMethod]
        public async Task SaveTaskTest()
        {

            testTask = Builder<DnpTask>.CreateNew().With(t => t.TaskID = 0).Build();
            testTask.ProjectStageID = stages[0].ID;

            testTask.TaskID = await _repository.SaveTask(testTask);
            
            Assert.AreNotEqual(0, testTask.TaskID, "Task not created.");

        }

        [TestMethod]
        public async Task GetTaskTest()
        {
            await SaveTaskTest();

            DnpTask existingTask = await _repository.GetTask(testTask.TaskID);

            Assert.AreEqual(testTask.TaskID, existingTask.TaskID, "Not a same task");
            Assert.AreEqual(testTask.ShortDescription, existingTask.ShortDescription, "Task not same");
            Assert.AreEqual(testTask.LongDescription, existingTask.LongDescription, "Task not same");
        }

        [TestMethod]
        public async Task GetTaskByProjectTest()
        {
            await SaveTaskTest();
            List<DnpTask> taskList = await _repository.GetTaskByProject(testProject.ID);

            Assert.AreEqual(1, taskList.Count, "Task List is not matching.");
        }

        [TestMethod]
        public async Task DeleteTaskByProjectTest()
        {
            await SaveTaskTest();

            await _repository.Delete(testTask.TaskID);

            DnpTask existingTask = await _repository.GetTask(testTask.TaskID);

            Assert.IsNull(existingTask, "Task is not deleted.");
        }
    }
}
