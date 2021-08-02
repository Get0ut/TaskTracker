using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public interface ITaskRepository
    {
        IEnumerable<Task> Tasks { get; }

        void AddTask(Task task);

        Task GetTask(long key);

        void UpdateTask(long id, string name, string description, TaskStatus status);

        void DeleteTask(long id);
    }
}
