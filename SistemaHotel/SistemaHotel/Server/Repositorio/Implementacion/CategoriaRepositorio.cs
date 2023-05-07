using Microsoft.EntityFrameworkCore;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Implementacion
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DbhotelBlazorContext _dbContext;

        public CategoriaRepositorio(DbhotelBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Categoria>> Consultar(Expression<Func<Categoria, bool>> filtro = null)
        {
            IQueryable<Categoria> queryEntidad = filtro == null ? _dbContext.Categoria : _dbContext.Categoria.Where(filtro);
            return queryEntidad;
        }

        public async Task<Categoria> Crear(Categoria entidad)
        {
            try
            {
                _dbContext.Set<Categoria>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Categoria entidad)
        {
            try
            {
                _dbContext.Categoria.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Categoria entidad)
        {
            try
            {
                _dbContext.Categoria.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Categoria>> Lista()
        {
            try
            {
                return await _dbContext.Categoria.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Categoria> Obtener(Expression<Func<Categoria, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Categoria.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
