using Microsoft.EntityFrameworkCore;
using VideoJuegos.Models;

namespace VideoJuegos.Context
{
    public class AplicacionContext : DbContext
    {
        public AplicacionContext(DbContextOptions<AplicacionContext> options)
            : base(options)
        {

        }

        public DbSet<Videojuego> Videojuegos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Email> Email { get; set; }
        // Puedes eliminar la siguiente línea si no necesitas la entidad "Titulo" en este contexto
    }
}
