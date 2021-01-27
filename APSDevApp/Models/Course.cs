using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace APSDevApp.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Course Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description should not be Empty !!!")]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}