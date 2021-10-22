using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Common;
using TaskManager.Core.Entities;
using TaskManager.Core.UsesCases.Tasks;

namespace TaskManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ApiController
    {
        private readonly ITaskInteractor _taskInteractor;

        public TaskController(ITaskInteractor taskInteractor)
        {
            _taskInteractor = taskInteractor ?? throw new ArgumentNullException(nameof(taskInteractor));
        }

        [HttpGet]
        public IActionResult Get()
        {
            Response response = _taskInteractor.GetTasks();
            return GetStatus(response.Status, response);
        }

        [HttpPost]
        public IActionResult Post(TaskEntity task)
        {
            Response response = _taskInteractor.InsertTask(task);
            return GetStatus(response.Status, response);
        }

        [HttpPut]
        public IActionResult Put(TaskEntity task)
        {
            Response response = _taskInteractor.UpdateTask(task);
            return GetStatus(response.Status, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response response = _taskInteractor.DeleteTask(id);
            return GetStatus(response.Status, response);
        }
    }
}
