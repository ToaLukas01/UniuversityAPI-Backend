using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models
{
    public class Student: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DOB { get; set; } //Date of Birth = fecha de nacimiento

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
