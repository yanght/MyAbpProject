using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyProject.Tasks;
using MyProject.Tasks.Dtos;

namespace UnitTestProject1
{
    [TestClass]
    public class TaskAppService_Test
    {
        private  ITaskAppService _taskAppService;
        
        [TestInitialize]
        public void Init()
        {
           
        }

        [TestMethod]
        public void TestMethod1()
        {
            GetTasksInput input = new GetTasksInput() { };

            var output = _taskAppService.GetTasks(input);

            Assert.AreNotEqual(output.Tasks.Count, 0);
        }
    }
}
