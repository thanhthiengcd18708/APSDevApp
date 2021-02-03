using APSDevApp.Models;
using System.Collections.Generic;

namespace APSDevApp.ViewModels
{
    public class ChangeAssignTrainee // TraineCoursesViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public Trainee Trainee { get; set; }
    }
}