using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APSDevApp.Models
{
    public class Trainee
    {
        [ForeignKey("ApplicationUser")]
        [Key]
        public string TraineeId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}