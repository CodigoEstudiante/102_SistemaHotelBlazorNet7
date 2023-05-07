using Microsoft.EntityFrameworkCore;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Implementacion
{
    public class HabitacionRepositorio : IHabitacionRepositorio
    {
        private readonly DbhotelBlazorContext _dbContext;

        public HabitacionRepositorio(DbhotelBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Habitacion>> Consultar(Expression<Func<Habitacion, bool>> filtro = null)
        {
            IQueryable<Habitacion> queryEntidad = filtro == null ? _dbContext.Habitacions : _dbContext.Habitacions.Where(filtro);
            return queryEntidad;
        }

        public async Task<Habitacion> Crear(Habitacion entidad)
        {
            try
            {
                _dbContext.Set<Habitacion>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Habitacion entidad)
        {
            try
            {
                _dbContext.Habitacions.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Habitacion entidad)
        {
            try
            {
                _dbContext.Habitacions.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Habitacion>> Lista()
        {
            try
            {
                return await _dbContext.Habitacions.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Habitacion> Obtener(Expression<Func<Habitacion, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Habitacions.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
