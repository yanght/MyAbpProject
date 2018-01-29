using Abp.Authorization;
using Abp.Web.Mvc.Controllers;
using MyProject.Tasks;
using MyProject.Tasks.Dtos;
using MyProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Web.Controllers
{
    //[AbpAuthorize]
    public class TasksController : AbpController
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }
        // GET: Tasks
        public ActionResult Index(GetTasksInput input)
        {
            var output = _taskAppService.GetTasks(input);

            var model = new IndexViewModel(output.Tasks)
            {
                SelectedTaskState = input.State

            };
            return View(model);

        }
    }
}