using Microsoft.EntityFrameworkCore;
using SistemaHotel.Server.Models;
using SistemaHotel.Server.Repositorio.Contratos;
using SistemaHotel.Shared;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Implementacion
{
    public class RecepcionRepositorio : IRecepcionRepositorio
    {

        private readonly DbhotelBlazorContext _dbContext;

        public RecepcionRepositorio(DbhotelBlazorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Recepcion>> Consultar(Expression<Func<Recepcion, bool>> filtro = null)
        {
            IQueryable<Recepcion> queryEntidad = filtro == null ? _dbContext.Recepcions : _dbContext.Recepcions.Where(filtro);
            return queryEntidad;
        }

        public async Task<Recepcion> Crear(Recepcion entidad)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    if(entidad.IdClienteNavigation.IdCliente == 0)
                    {
                        var cliente = entidad.IdClienteNavigation;
                        _dbContext.Clientes.Add(cliente);
                        await _dbContext.SaveChangesAsync();

                        entidad.IdCliente = cliente.IdCliente;
                        entidad.IdClienteNavigation = null;
                    }
                    else
                    {
                        entidad.IdCliente = entidad.IdClienteNavigation.IdCliente;
                        entidad.IdClienteNavigation = null;
                    }

                    var habitacion = await _dbContext.Habitacions.Where(h => h.IdHabitacion == entidad.IdHabitacion).FirstAsync();

                    habitacion.IdEstadoHabitacion = 3;
                    _dbContext.Habitacions.Update(habitacion);
                    await _dbContext.SaveChangesAsync();


                    if (entidad.Adelanto == null)
                        entidad.Adelanto = 0;

                    _dbContext.Recepcions.Add(entidad);
                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();

                    return entidad;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public async Task<bool> Editar(Recepcion entidad)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var habitacion = await _dbContext.Habitacions.Where(h => h.IdHabitacion == entidad.IdHabitacion).FirstAsync();

                    habitacion.IdEstadoHabitacion = 2;
                    _dbContext.Habitacions.Update(habitacion);
                    await _dbContext.SaveChangesAsync();

                    entidad.Estado = false;
                    entidad.IdHabitacionNavigation = null;
                    entidad.IdClienteNavigation = null;
                    _dbContext.Recepcions.Update(entidad);
                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }



        public async Task<Recepcion> Obtener(Expression<Func<Recepcion, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Recepcions.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public  async Task<List<Recepcion>> Reporte(string FechaInicio, string FechaFin)
        {
            DateTime fech_Inicio = DateTime.ParseExact(FechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
            DateTime fech_Fin = DateTime.ParseExact(FechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));

            List<Recepcion> listaResumen = await _dbContext.Recepcions
                .Include(p => p.IdClienteNavigation)
                .Include(v => v.IdHabitacionNavigation)
                 .Where(dv => dv.FechaEntrada.Value.Date >= fech_Inicio.Date && dv.FechaEntrada.Value.Date <= fech_Fin.Date)
                .ToListAsync();

            return listaResumen;
        }
    }
}
