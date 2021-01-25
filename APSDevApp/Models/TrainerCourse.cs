using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace APSDevApp.Models
{
    public class TrainerCourse
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}