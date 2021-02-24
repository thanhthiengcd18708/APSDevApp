using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APSDevApp.Models;
namespace APSDevApp.ViewModels
{
    public class ListTrainerAccount
    {
        public List<Trainer> Trainers { get; set; }
        public List<ApplicationUser> Users { get; set; }

    }
}