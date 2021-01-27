using APSDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APSDevApp.ViewModels
{
    public class AssignTrainerToCourse
    {
        public Course Course { get; set; }
        public Trainer Trainers { get; set; }
    }
}