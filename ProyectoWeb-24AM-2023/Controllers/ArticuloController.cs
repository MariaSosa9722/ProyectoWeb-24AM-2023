using Azure;
using Microsoft.AspNetCore.Mvc;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;
using ProyectoWeb_24AM_2023.Services.Service;

namespace ProyectoWeb_24AM_2023.Controllers
{
    public class ArticuloController : Controller
    {

        private readonly IArticuloServices _articuloServices;
        public ArticuloController(IArticuloServices articuloServices)
        {
            _articuloServices = articuloServices;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                //Modo de pensar junior xd
                //var response = await _articuloServices.GetArticulos();

                //return View(response);

                //Modo de pensar Senior profa majo
                return View(await _articuloServices.GetArticulos());


            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Articulo request)
        {
            var response = _articuloServices.CrearArticulo(request);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {

            var response = await _articuloServices.GetByIdArticulo(id);
            return View(response);
        }





        [HttpPost]
        public IActionResult Editar(Articulo request)
        {
            var response = _articuloServices.EditarArticulo(request);


            return RedirectToAction(nameof(Index));
        }


        //[HttpDelete]
        //public bool Eliminar(int id)
        //{
        //    bool result =  _articuloService.DeleteArticulo(id);

        //    return result;

        //}


        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            bool result = _articuloServices.EliminarArticulo(id);
            if (result == true)
            {
                return Json(new { succes = true });
            }
            else
            {
                return Json(new { succes = false });
            }

        }




    }
}
