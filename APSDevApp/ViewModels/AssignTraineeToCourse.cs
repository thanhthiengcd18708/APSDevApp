using APSDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APSDevApp.ViewModels
{
    public class AssignTraineeToCourse // CourseTraineeViewModel
    {
        public Course Course { get; set; }
        public Trainee Trainees { get; set; }
    }
}