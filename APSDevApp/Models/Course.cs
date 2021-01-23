using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APSDevApp.Models
{
	public class Course
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Name should not be Empty !!!")]
		[StringLength(255)]
		[DisplayName("Task Name")]
		public string Name { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public string Dc { get; set; }
		
	}
}