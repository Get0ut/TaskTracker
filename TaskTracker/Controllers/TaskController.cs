using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskRepository repository;

        public TaskController(ITaskRepository repo) => repository = repo;

        /// <summary>
        /// Get all Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Task> GetTasks()
        {
            return repository.Tasks;
        }

        /// <summary>
        /// Add new task
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void AddTask(string name, string description, int projectId, Priority priority)
        {
            repository.AddTask(new Task()
            {
                Name = name,
                Priority = priority,
                Status = TaskStatus.ToDo,              //When task is creating then status should be "ToDo" by default
                ProjectId = projectId,
                Discription = description
            });
        }

        /// <summary>
        /// Update Task
        /// </summary>
        [HttpPut("{id}")]
        public void UpdateTask(long id, string name, string description, TaskStatus status)
        {
            repository.UpdateTask(id, name, description, status);
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            repository.DeleteTask(id);
        }
    }
}
