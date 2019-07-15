using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using TaskManageraApi.Models;
using TaskManagerDal;

namespace MVC_App.Tests.Controllers
{
    [TestFixture]
    public class TaskManagerControllerTest
    {
        [Test]
        public void GetAllTask()
        {
            IList<TaskMaster> lstTaskMaster = new List<TaskMaster>() {
            new TaskMaster()
            {
                Task_Id =1,
                Parent_Id =1,
                Task_Name = "Task 1",
                ParentTask_Name = "Parent Task 1",
                Priority =2,
                Start_Date = "06/01/2019",
                End_Date = "06/02/2019"},
            new TaskMaster()
            {
                Task_Id =2,
                Parent_Id =2,
                Task_Name = "Task 1",
                ParentTask_Name = "Parent Task 2",
                Priority =2,
                Start_Date = "06/03/2019",
                End_Date = "06/04/2019"}
            };
            var mock = new Mock<ITaskManagerController>();
            mock.Setup(q => q.GetAllTask()).Returns(lstTaskMaster);
            Assert.AreEqual(2, mock.Object.GetAllTask().Count);
        }

        [TestCase("Task 1", "Parent Task 1","12","23", "06/12/2019", "06/13/2019")]
        [TestCase("Task 2", "Parent Task 2", "2", "5", "06/14/2019", "06/15/2019")]
        [TestCase("Task 3", "Parent Task 3", "0", "30", "06/16/2019", "06/17/2019")]
        public void FilterTask(string task, string parentTask, string priorityFrom, string priorityTo, string dateFrom, string dateTo)
        {
            IList<TaskMaster> lstTaskMaster = new List<TaskMaster>() {
            new TaskMaster()
            {
                Task_Id =1,
                Parent_Id =1,
                Task_Name = "Task 1",
                ParentTask_Name = "Parent Task 1",
                Priority =2,
                Start_Date = "06/01/2019",
                End_Date = "06/02/2019"},
            new TaskMaster()
            {
                Task_Id =2,
                Parent_Id =2,
                Task_Name = "Task 1",
                ParentTask_Name = "Parent Task 2",
                Priority =2,
                Start_Date = "06/03/2019",
                End_Date = "06/04/2019"}
            };
            var mock = new Mock<ITaskManagerController>();
            mock.Setup(q => q.FilterTask(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(lstTaskMaster);
            Assert.AreEqual(2, mock.Object.FilterTask(task, parentTask, priorityFrom, priorityTo, dateFrom, dateTo).Count);
        }

        [Test]
        public void AddParentTask()
        {
            ParentTask item = new ParentTask()
            {
                Parent_Id = 1,
                Parent_Task = "Parent Task 1"
            };

            var mock = new Mock<ITaskManagerController>();
            mock.Setup(q => q.AddParentTask(item)).Returns(CodeAndReason.Ok("Success"));
            CodeAndReason result = (CodeAndReason)mock.Object.AddParentTask(item);
            Assert.AreEqual(result.Code, HttpStatusCode.OK);
        }

        [Test]
        public void EditParentTask()
        {
            ParentTask item = new ParentTask()
            {
                Parent_Id = 1,
                Parent_Task = "Parent Task 1"
            };

            var mock = new Mock<ITaskManagerController>();
            mock.Setup(q => q.EditParentTask(item)).Returns(CodeAndReason.Ok("Success"));
            CodeAndReason result = (CodeAndReason)mock.Object.EditParentTask(item);
            Assert.AreEqual(result.Code, HttpStatusCode.OK);
        }

        [Test]
        public void AddTask()
        {
            Task item = new Task()
            {
                Task_Id = 2,
                Parent_Id = 2,
                Task_Name = "Task 1",
                Priority = 2,
                Start_Date = "06/03/2019",
                End_Date = "06/04/2019"
            };

            var mock = new Mock<ITaskManagerController>();
            mock.Setup(q => q.AddTask(item)).Returns(CodeAndReason.Ok("Success"));
            CodeAndReason result = (CodeAndReason)mock.Object.AddTask(item);
            Assert.AreEqual(result.Code, HttpStatusCode.OK);
        }

        [Test]
        public void EditTask()
        {
            Task item = new Task()
            {
                Task_Id = 2,
                Parent_Id = 2,
                Task_Name = "Task 1",
                Priority = 2,
                Start_Date = "06/03/2019",
                End_Date = "06/04/2019"
            };

            var mock = new Mock<ITaskManagerController>();
            mock.Setup(q => q.EditTask(item)).Returns(CodeAndReason.Ok("Success"));
            CodeAndReason result = (CodeAndReason)mock.Object.EditTask(item);
            Assert.AreEqual(result.Code, HttpStatusCode.OK);
        }
    }
}
