using APSDevApp.Models;
using System.Collections.Generic;

namespace APSDevApp.ViewModels
{
    public class TrainerandTraineeCourseList // TraineesTrainersCourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
    }
}