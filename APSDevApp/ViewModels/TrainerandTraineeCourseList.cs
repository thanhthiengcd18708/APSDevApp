using APSDevApp.Models;
using System.Collections.Generic;

namespace APSDevApp.ViewModels
{
    public class TrainerandTraineeCourseList
    {
        public Course Course { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
    }
}