using APSDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APSDevApp.ViewModels
{
    public class UserProfile
    {
        public Trainer TrainerInWeb { get; set; }
        public Trainee TraineeInWeb { get; set; }
        public ApplicationUser UserInWeb { get; set; }
    }
}