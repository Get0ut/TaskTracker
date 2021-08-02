using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class Task
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Discription { get; set; }
        
        public Priority Priority { get; set; }

        public long ProjectId { get; set; }

        public Project Project { get; set; }

        public TaskStatus Status { get; set; }
    }
}
