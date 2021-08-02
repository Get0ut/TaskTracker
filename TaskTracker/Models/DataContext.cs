using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> ctx) : base(ctx) { }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
