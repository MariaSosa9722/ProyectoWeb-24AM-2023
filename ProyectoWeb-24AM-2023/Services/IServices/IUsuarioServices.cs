using ProyectoWeb_24AM_2023.Models.Entities;

namespace ProyectoWeb_24AM_2023.Services.IServices
{
    public interface IUsuarioServices
    {

        public Task<List<Usuario>> GetAll();

        public Task<Usuario> GetbyId(int id);
        public Task<Usuario> Crear(Usuario i);

        public Task<Usuario> Editar(Usuario i);
    }
}
