using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public class Project
    {
        //public Project(string name, Priority )
        //{
        //    Name = name;
        //    Priority = 
        //}

        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public Priority Priority { get; set; }

        public DateTime DataStart { get; set; }

        public DateTime DataEnd { get; set; }

        public ProjectStatus Status{ get; set; }
    }
}
