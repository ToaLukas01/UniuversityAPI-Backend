//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models
{
    public class User: BaseEntity // indicamos que este modelo sera de la clase "BaseEntity" lo cual hara que herede todas las propiedades de "BaseEntity"
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Lastname { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
