using Microsoft.AspNetCore.Mvc;
using WebApiWayni.Models;
using WebApiWayni.Services;

namespace WebApiWayni.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        IUsuariosService usuarioService;

        public UsuarioController(IUsuariosService service)
        {
            usuarioService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(usuarioService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(usuarioService.Get(id));
        }

        [HttpGet("ExisteDNI/{dni}")]
        public IActionResult GetExisteDNI(string dni,Guid? id)
        {
            return Ok(usuarioService.GetExisteDNI(dni,id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("El usuario no puede ser nulo o vacio.");
            }
            try
            {
                await usuarioService.Save(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al almacenar el usuario: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest("El usuario no puede ser nulo o vacio.");
            }
            try
            {
                await usuarioService.Update(id, usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar el usuario: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await usuarioService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar el usuario: {ex.Message}");
            }
        }
    }
}
