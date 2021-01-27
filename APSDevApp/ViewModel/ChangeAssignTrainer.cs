using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APSDevApp.Models;

namespace APSDevApp.ViewModel
{
    public class ChangeAssignTrainer
    {
        public IEnumerable<Course> Courses { get; set; }
        public Trainer Trainer { get; set; }
    }
}