using Microsoft.EntityFrameworkCore;
using ProyectoWeb_24AM_2023.Context;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;
using System.Diagnostics.Eventing.Reader;

namespace ProyectoWeb_24AM_2023.Services.Service
{
    public class ArticuloServices : IArticuloServices
    {
        private readonly ApplicationDbContext _context;
        public ArticuloServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Articulo>> GetArticulos()
        {
            try
            {
                
                 return await _context.Articulos.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error"+ex.Message);
            }

        }

        public async Task<Articulo> GetByIdArticulo(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Articulo response = await _context.Articulos.FirstOrDefaultAsync(x => x.PkArticulo == id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Articulo> CrearArticulo(Articulo i)
        {
            try
            {
                Articulo request = new Articulo() 
                {
                    Nombre = i.Nombre,  
                    Descripcion = i.Descripcion,
                    Precio = i.Precio,
                };

                var result =  _context.Articulos.Add(request);
                                await _context.SaveChangesAsync();

                return request;
                            

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }


        public bool EliminarArticulo(int id)
        {
            try
            {
                Articulo articulo = _context.Articulos.Find(id);
                var res = _context.Articulos.Remove(articulo);
                _context.SaveChanges();

                if (articulo != null)
                {
                    return true;

                }

                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Succedio un error " + ex.Message);
            }

        }

    }
}
