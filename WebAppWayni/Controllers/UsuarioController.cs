using Microsoft.AspNetCore.Mvc;
using WebAppWayni.Models;
using WebAppWayni.Services.Interfaces;

namespace WebAppWayni.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            return View(usuarios);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {

            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            if (await _usuarioService.GetExisteDNIAsync(usuario.Dni,null))
            {
                ModelState.AddModelError("Dni", "El DNI ya está registrado.");
                return View(usuario);
            }

            var success = await _usuarioService.PostUsuarioAsync(usuario);
            
            if (!success)
            {
                return StatusCode(500, "Error al crear el usuario.");
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var usuario = await _usuarioService.GetUsuarioAsync(id);
            return View(usuario);
        }

        // PUT: Usuario (Actualizar un usuario existente)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            
            if (await _usuarioService.GetExisteDNIAsync(usuario.Dni, usuario.Id))
            {
                ModelState.AddModelError("Dni", "El DNI ya está registrado para otro usuario.");
                return View(usuario);
            }

            var success = await _usuarioService.PutUsuarioAsync(id, usuario);

            if (!success)
            {
                return StatusCode(500, "Error al actualizar el usuario.");
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var usuario = await _usuarioService.GetUsuarioAsync(id);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _usuarioService.DeleteUsuarioAsync(id);

            if (!success)
            {
                return StatusCode(500, "Error al eliminar el usuario.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
