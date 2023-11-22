using Microsoft.AspNetCore.Mvc;
using ProyectoWeb_24AM_2023.Services.IServices;

namespace ProyectoWeb_24AM_2023.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IUsuarioServices _usuarioServices;

        
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices= usuarioServices;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _usuarioServices.GetAll();
            return View(response);
        }


        [HttpGet]
        public IActionResult Crear()
        {

            return View();
        }
    }
}
