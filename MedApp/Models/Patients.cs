using System.ComponentModel.DataAnnotations;

namespace MedApp.Models
{
    public class Patients
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }

    }
}