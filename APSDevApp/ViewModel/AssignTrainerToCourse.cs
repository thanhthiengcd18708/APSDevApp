using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APSDevApp.Models;

namespace APSDevApp.ViewModel
{
    public class AssignTrainerToCourse
    {
        public Course Course { get; set; }
        public Trainer Trainers { get; set; }
    }
}