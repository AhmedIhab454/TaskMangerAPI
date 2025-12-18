using Microsoft.AspNetCore.Mvc;           
using TaskMangerAPI.Models;                        
using System.Collections.Generic;
using TaskMangerAPI.DTOs;

namespace TaskMangerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<TaskItems> tasks = new List<TaskItems>
        {

        new TaskItems { Id = 1, Title = "First Task", Description = "This is the first task", IsCompleted = false },
        new TaskItems { Id = 2, Title = "Second Task", Description = "This is the second task", IsCompleted = true }


        };

        //Get
        [HttpGet]
        public ActionResult<List<TaskItems>> GetTasks()
        {
            return Ok(tasks);
        }

        //Post
        [HttpPost]
        public ActionResult<TaskItems> CreateTask([FromBody] CreateTaskDto newTaskDto)
        {
            int newId = tasks.Count > 0 ? tasks[^1].Id + 1 : 1;
            var task= new TaskItems
            {
                Id = newId,
                Title = newTaskDto.Title,
                Description = newTaskDto.Description,
                IsCompleted = false
            };
            tasks.Add(task);
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

    }
}
