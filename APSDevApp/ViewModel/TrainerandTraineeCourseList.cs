using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APSDevApp.Models;

namespace APSDevApp.ViewModel
{
    public class TrainerandTraineeCourseList
    {
        public Course Course { get; set; }
        public IEnumerable<Trainer> Trainers { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
    }
}