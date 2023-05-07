using Microsoft.EntityFrameworkCore;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Implementacion
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DbhotelBlazorContext _dbContext;

        public ClienteRepositorio(DbhotelBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<Cliente>> Consultar(Expression<Func<Cliente, bool>> filtro = null)
        {
            IQueryable<Cliente> queryEntidad = filtro == null ? _dbContext.Clientes : _dbContext.Clientes.Where(filtro);
            return queryEntidad;
        }

        public async Task<Cliente> Crear(Cliente entidad)
        {
            try
            {
                _dbContext.Set<Cliente>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Cliente entidad)
        {
            try
            {
                _dbContext.Clientes.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Cliente entidad)
        {
            try
            {
                _dbContext.Clientes.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Cliente>> Lista()
        {
            try
            {
                return await _dbContext.Clientes.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Cliente> Obtener(Expression<Func<Cliente, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Clientes.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
