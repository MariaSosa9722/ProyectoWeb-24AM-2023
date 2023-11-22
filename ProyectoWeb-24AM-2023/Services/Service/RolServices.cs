using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectoWeb_24AM_2023.Context;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;
using System.Threading.Tasks.Sources;

namespace ProyectoWeb_24AM_2023.Services.Service
{
    public class RolServices : IRolServices
    {

        private readonly ApplicationDbContext _context;

        public RolServices(ApplicationDbContext context)
        {
            _context= context;
        }

        public async Task<List<Rol>> GetAll()
        {
            try
            {

                var response = await _context.Roles.ToListAsync();
                return response;    

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
