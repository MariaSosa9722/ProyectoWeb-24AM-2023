using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoWeb_24AM_2023.Context;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;
using ProyectoWeb_24AM_2023.Services.Service;

namespace ProyectoWeb_24AM_2023.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IUsuarioServices _usuarioServices;
        private readonly ApplicationDbContext _context;


        public UsuariosController(IUsuarioServices usuarioServices, ApplicationDbContext context)
        {
            _usuarioServices= usuarioServices;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _usuarioServices.GetAll();
            return View(response);
        }


        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRoles.ToString()
            });

            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {

            var response = _usuarioServices.Crear(usuario);

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {

            var response = await _usuarioServices.GetbyId(id);

            ViewBag.Roles = _context.Roles.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkRoles.ToString()
            });

            return View(response);
        }


        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {

            var response = _usuarioServices.Editar(usuario);
            return RedirectToAction(nameof(Index));
        }

    }
}
