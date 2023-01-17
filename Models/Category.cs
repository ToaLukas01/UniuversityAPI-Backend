using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Course> Courses { get; set;} = new List<Course>();  // aqui hacemos la relacion de que una categoria puede pertenecera varios cursos  

    }
}
