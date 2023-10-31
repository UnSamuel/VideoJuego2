using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VideoJuegos.Context;
using VideoJuegos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoJuegos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideojuegosController : Controller
    {
        private readonly AplicacionContext aplicacionContext;

        public VideojuegosController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }

        public AplicacionContext GetAplicacionContext()
        {
            return aplicacionContext;
        }

        [HttpGet]
        [Route("MostrarVideojuegos")]
        public IActionResult MostrarVideojuegos(AplicacionContext aplicacionContext)
        {
            List<Videojuego> videojuegos = aplicacionContext.Videojuegos.ToList();
            return StatusCode(StatusCodes.Status200OK, videojuegos);
        }

        [HttpPost]
        [Route("CrearVideojuego")]
        public IActionResult CrearVideojuego([FromBody] Videojuego videojuego)
        {
            aplicacionContext.Videojuegos.Add(videojuego);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Videojuego Creado Correctamente");
        }

        [HttpPut]
        [Route("EditarVideojuego")]
        public IActionResult EditarVideojuego([FromBody] Videojuego videojuego)
        {
            aplicacionContext.Videojuegos.Update(videojuego);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Videojuego Editado Correctamente");
        }

        [HttpDelete]
        [Route("EliminarVideojuego/{id}")]
        public IActionResult EliminarVideojuego(int id)
        {
            Videojuego videojuego = aplicacionContext.Videojuegos.Find(id);
            if (videojuego != null)
            {
                aplicacionContext.Videojuegos.Remove(videojuego);
                aplicacionContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Videojuego Eliminado Correctamente");
            }
            return StatusCode(StatusCodes.Status404NotFound, "Videojuego no encontrado");
        }
    }
}
