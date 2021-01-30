using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APSDevApp.Models
{
    public class Trainer
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string TrainerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string WorkingPlace { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? CourseId { get; set; }
        public Course course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}