using Microsoft.EntityFrameworkCore;
using ProyectoWeb_24AM_2023.Context;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;

namespace ProyectoWeb_24AM_2023.Services.Service
{
    public class UsuarioServices : IUsuarioServices
    {

        private readonly ApplicationDbContext _context;

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAll()
        {

            try
            {

                var res = await _context.Usuarios.ToListAsync();
                return res;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public async Task<Usuario> Crear(Usuario i)
        {

            try
            {

                Usuario request = new Usuario()
                {
                    Nombre = i.Nombre,
                    Apellido= i.Apellido,
                    UserName= i.UserName,
                    Password= i.Password,
                    FkRol = i.FkRol
                };

                var response = await _context.Usuarios.AddAsync(request);
                                _context.SaveChanges();

                return request;

            }
            catch (Exception)
            {

                throw;
            }

        }



        public async Task<Usuario> Editar(Usuario i)
        {
            try
            {

                Usuario usuario = _context.Usuarios.Find(i.PKUsuario);

                usuario.Nombre = i.Nombre;
                usuario.UserName = i.UserName;
                usuario.FkRol = i.FkRol;

                _context.Entry(usuario).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return usuario;

            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<Usuario> GetbyId(int id)
        {
            try
            {
                var response = await _context.Usuarios.FirstOrDefaultAsync(x => x.PKUsuario == id);

                return response;

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }

        }


    }
}
