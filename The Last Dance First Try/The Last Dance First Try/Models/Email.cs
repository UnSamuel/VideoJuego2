using System;
using System.ComponentModel.DataAnnotations;

namespace VideoJuegos.Models
{
    public class Email
    {
        [Key]
        public int Idemail { get; set; }

        [Required]
        [StringLength(255)]
        public string DireccionEmail { get; set; }

        public int Idusuario { get; set; }
    }
}
