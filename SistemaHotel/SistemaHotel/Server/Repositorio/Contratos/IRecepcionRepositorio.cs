using SistemaHotel.Server.Models;
using SistemaHotel.Shared;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Contratos
{
    public interface IRecepcionRepositorio
    {
        Task<IQueryable<Recepcion>> Consultar(Expression<Func<Recepcion, bool>> filtro = null);
        Task<Recepcion> Obtener(Expression<Func<Recepcion, bool>> filtro = null);
        Task<Recepcion> Crear(Recepcion entidad);
        Task<bool> Editar(Recepcion entidad);
        Task<List<Recepcion>> Reporte(string FechaInicio, string FechaFin);
    }
}
