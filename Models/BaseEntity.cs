
using System.ComponentModel.DataAnnotations; // este using nos permite establecer una estructura para crear los modelos de la Base de Datos

namespace UniversityApiBackend.Models
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        //public int UserID { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } // con el signo de pregunta "?" estamos indicando que este valor puede venir o NO
        public DateTime? DeletedAt { get; set; } 
        public bool IsDeleted { get; set; } = false;

    }
}
