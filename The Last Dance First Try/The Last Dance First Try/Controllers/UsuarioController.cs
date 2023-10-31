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
    public class UsuarioController : Controller
    {
        private readonly AplicacionContext aplicacionContext;

        public UsuarioController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }

        [HttpGet]
        [Route("MostrarUsuarios")]
        public IActionResult MostrarUsuarios()
        {
            List<Usuario> usuarios = aplicacionContext.Usuario.ToList();
            return StatusCode(StatusCodes.Status200OK, usuarios);
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            aplicacionContext.Usuario.Add(usuario);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Usuario Creado Correctamente");
        }

        [HttpPut]
        [Route("EditarUsuario")]
        public IActionResult EditarUsuario([FromBody] Usuario usuario)
        {
            aplicacionContext.Usuario.Update(usuario);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Usuario Editado Correctamente");
        }

        [HttpDelete]
        [Route("EliminarUsuario/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            Usuario usuario = aplicacionContext.Usuario.Find(id);
            if (usuario != null)
            {
                aplicacionContext.Usuario.Remove(usuario);
                aplicacionContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Usuario Eliminado Correctamente");
            }
            return StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado");
        }
    }
}
