using ProyectoWeb_24AM_2023.Models.Entities;

namespace ProyectoWeb_24AM_2023.Services.IServices
{
    public interface IUsuarioServices
    {

        public Task<List<Usuario>> GetAll();
    }
}
