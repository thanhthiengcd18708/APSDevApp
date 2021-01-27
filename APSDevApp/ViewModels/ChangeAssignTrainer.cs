using APSDevApp.Models;
using System.Collections.Generic;

namespace APSDevApp.ViewModels
{
    public class ChangeAssignTrainer
    {
        public IEnumerable<Course> Courses { get; set; }
        public Trainer Trainer { get; set; }
    }
}