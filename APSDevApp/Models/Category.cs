using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APSDevApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Category DC")]
        public string Dc { get; set; }

    }
}