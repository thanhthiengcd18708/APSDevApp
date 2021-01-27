using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APSDevApp.Models;

namespace APSDevApp.ViewModel
{
    public class ChangeAssignTrainee
    {
        public IEnumerable<Course> Courses { get; set; }
        public Trainee Trainee { get; set; }
    }
}