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
    public class EmailController : Controller
    {
        private readonly AplicacionContext aplicacionContext;

        public EmailController(AplicacionContext _aplicacionContext)
        {
            aplicacionContext = _aplicacionContext;
        }

        [HttpGet]
        [Route("MostrarEmails")]
        public IActionResult MostrarEmails()
        {
            List<Email> emails = aplicacionContext.Email.ToList();
            return StatusCode(StatusCodes.Status200OK, emails);
        }

        [HttpPost]
        [Route("CrearEmail")]
        public IActionResult CrearEmail([FromBody] Email email)
        {
            aplicacionContext.Email.Add(email);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Email Creado Correctamente");
        }

        [HttpPut]
        [Route("EditarEmail")]
        public IActionResult EditarEmail([FromBody] Email email)
        {
            aplicacionContext.Email.Update(email);
            aplicacionContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, "Email Editado Correctamente");
        }

        [HttpDelete]
        [Route("EliminarEmail/{id}")]
        public IActionResult EliminarEmail(int id)
        {
            Email email = aplicacionContext.Email.Find(id);
            if (email != null)
            {
                aplicacionContext.Email.Remove(email);
                aplicacionContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Email Eliminado Correctamente");
            }
            return StatusCode(StatusCodes.Status404NotFound, "Email no encontrado");
        }
    }
}
