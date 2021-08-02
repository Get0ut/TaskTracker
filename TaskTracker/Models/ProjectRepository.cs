using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private DataContext context;

        public ProjectRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Project> Projects => context.Projects;

        public void AddProject(Project project)
        {
            if (project.Priority == 0)                          //Priority should not be null. Set "Low" priority instead of zero
                project.Priority = (Priority)3;
            this.context.Projects.Add(project);
            this.context.SaveChanges();
        }

        public Project GetProject(long key) => context.Projects.Find(key);

        public void UpdateProject(long id, ProjectStatus status, string value)
        {
            Project project = GetProject(id);
            project.Name = value;
            if(status != 0)                                     //Check because the status must be set
            {
                if (project.Status != status)                   // Change status only if it has changed
                    ChangeStatus(project, status);
            }
            
            context.SaveChanges();
        }

        public void DeleteProject(long id)
        {
            Project project = GetProject(id);
            context.Tasks.RemoveRange(GetTasks(id));            //Delete all tasks that the project contains
            context.Projects.Remove(project);
            context.SaveChanges();
        }

        private void ChangeStatus(Project project, ProjectStatus status)
        {
            project.Status = status;
            switch (status)                                     //Sets time depending on the status 
            {
                case ProjectStatus.Active:
                    project.DataStart = DateTime.Now;
                    break;
                case ProjectStatus.Completed:
                    project.DataEnd = DateTime.Now;
                    break;
                default:
                    project.DataEnd = DateTime.MinValue;
                    project.DataStart = DateTime.MinValue;
                    break;
            }
            context.SaveChanges();
        }

        public IEnumerable<Task> GetTasks(long id)
        {
            return context.Tasks.Where(t => t.ProjectId == id);
        }
    }
}
