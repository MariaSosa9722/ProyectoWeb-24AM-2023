using Microsoft.AspNetCore.Mvc;
using ProyectoWeb_24AM_2023.Services.IServices;
using ProyectoWeb_24AM_2023.Services.Service;

namespace ProyectoWeb_24AM_2023.Controllers
{
    public class ArticuloController : Controller
    {

        private readonly IArticuloServices _articuloServices;
        public ArticuloController(IArticuloServices articuloServices)
        {
            _articuloServices= articuloServices;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                var response = await _articuloServices.GetArticulos();

                return View(response);


            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }

        }




    }
}
