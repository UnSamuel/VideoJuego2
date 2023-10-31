using System;
using System.ComponentModel.DataAnnotations;

namespace VideoJuegos.Models
{
    public class Usuario
    {
        [Key]
        public int Idusuario { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Genero { get; set; }

        public int Edad { get; set; }
    }
}
