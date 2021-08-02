using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectRepository repository;

        public ProjectController(IProjectRepository repo) => repository = repo;

        /// <summary>
        /// Get all projects
        /// </summary>
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return repository.Projects;
        }

        /// <summary>
        /// Get project's tasks
        /// </summary>
        [HttpGet("{id}")]
        public IEnumerable<Task> GetTasks(long id)
        {
            return repository.GetTasks(id);
        }

        /// <summary>
        /// Add new project
        /// </summary>
        [HttpPost]
        public void AddProject(string name, Priority priority)
        {
            repository.AddProject(new Project()
            {
                Name = name,
                Priority = priority,
                Status = ProjectStatus.NotStarted  //when project is creating then "NotStarted" status should be set as default
            });
        }

        /// <summary>
        /// Update project
        /// </summary>
        [HttpPut("{id}")]
        public void UpdateProject(long id, ProjectStatus status, string name)
        {
            repository.UpdateProject(id, status, name);

        }

        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            repository.DeleteProject(id);
        }
    }
}
