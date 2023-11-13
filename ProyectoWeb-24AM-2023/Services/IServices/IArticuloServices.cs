using ProyectoWeb_24AM_2023.Models.Entities;

namespace ProyectoWeb_24AM_2023.Services.IServices
{
    public interface IArticuloServices
    {
        public Task<List<Articulo>> GetArticulos();
        public Task<Articulo> GetByIdArticulo(int id);

        public Task<Articulo> CrearArticulo(Articulo i);

        public bool EliminarArticulo(int id);
    }
}
