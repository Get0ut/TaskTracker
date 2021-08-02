using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class TaskRepository : ITaskRepository
    {
        private DataContext context;

        public TaskRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Task> Tasks => context.Tasks.Include(t => t.Project).ToArray();

        public void AddTask(Task task)
        {
            this.context.Tasks.Add(task);
            this.context.SaveChanges();
        }

        public Task GetTask(long key) => context.Tasks.Include(t => t.Project).First(t => t.Id == key);

        public void UpdateTask(long id, string name, string description, TaskStatus status)
        {
            Task task = GetTask(id);
            task.Name = name;
            task.Discription = description;
            if (status != 0)                         //Check because status shoud be define
                task.Status = status;
            context.SaveChanges();
        }

        public void DeleteTask(long id)
        {
            Task task = GetTask(id);
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
    }
}
