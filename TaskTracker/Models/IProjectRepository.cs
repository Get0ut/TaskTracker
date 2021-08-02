using System.Collections.Generic;

namespace TaskTracker.Models
{
    public interface IProjectRepository
    {
        IEnumerable<Project> Projects{ get; }

        void AddProject(Project project);

        Project GetProject(long key);

        void UpdateProject(long id, ProjectStatus status, string value);

        void DeleteProject(long id);

        IEnumerable<Task> GetTasks(long id);
    }
}