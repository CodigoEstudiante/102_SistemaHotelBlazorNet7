using Microsoft.EntityFrameworkCore;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;

namespace SistemaHotel.Server.Repositorio.Implementacion
{
    public class RolUsuarioRepositorio : IRolUsuarioRepositorio
    {
        private readonly DbhotelBlazorContext _dbContext;

        public RolUsuarioRepositorio(DbhotelBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RolUsuario>> Lista()
        {
            try
            {
                return await _dbContext.RolUsuarios.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
