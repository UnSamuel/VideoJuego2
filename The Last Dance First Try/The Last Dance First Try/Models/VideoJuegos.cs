using System;
using System.ComponentModel.DataAnnotations;

namespace VideoJuegos.Models
{
    public class Videojuego
    {
        [Key]
        public int Idvideojuego { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoDePago { get; set; }

        public bool EsGrupal { get; set; }

        [StringLength(50)]
        public string Tipo { get; set; }

        public int IdUsuario { get; set; }
    }
}
