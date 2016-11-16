using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dnp.Kanban.Domain;
using System.Transactions;
using FizzWare.NBuilder;

namespace Dnp.Kanban.SqlRepository.Tests
{
    [TestClass]
    public class TaskRepositoryTest
    {
        ITaskRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            MapperSetup.InitializeMapper();

            _repository = new SqlTaskRepository("DefaultConnection");
        }

        //[TestMethod]
        //public void SaveTaskTest()
        //{
        //    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        //    {

        //        DnpTask task = Builder<DnpTask>.CreateNew().With(t => { t.TaskID = 0; t.ProjectStageID = 3; }).Build();

        //    }

        //}
    }
}
