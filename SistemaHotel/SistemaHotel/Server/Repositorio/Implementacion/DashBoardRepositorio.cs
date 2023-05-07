using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;

namespace SistemaHotel.Server.Repositorio.Implementacion
{
    public class DashBoardRepositorio : IDashBoardRepositorio
    {
        private readonly DbhotelBlazorContext _dbContext;

        public DashBoardRepositorio(DbhotelBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> HabitacionesDisponibles()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Where(h => h.IdEstadoHabitacion == 1).Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> HabitacionesLimpieza()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Where(h => h.IdEstadoHabitacion == 2).Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> HabitacionesOcupadas()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Where(h => h.IdEstadoHabitacion == 3).Count();
                return total;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> TotalHabitaciones()
        {
            try
            {
                IQueryable<Habitacion> query = _dbContext.Habitacions;
                int total = query.Count();
                return total;
            }
            catch
            {
                throw;
            }
        }
    }
}
