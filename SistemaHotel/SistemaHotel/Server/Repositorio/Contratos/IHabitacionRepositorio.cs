using SistemaHotel.Server.Models;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Contratos
{
    public interface IHabitacionRepositorio
    {
        Task<List<Habitacion>> Lista();
        Task<Habitacion> Obtener(Expression<Func<Habitacion, bool>> filtro = null);
        Task<Habitacion> Crear(Habitacion entidad);
        Task<bool> Editar(Habitacion entidad);
        Task<bool> Eliminar(Habitacion entidad);
        Task<IQueryable<Habitacion>> Consultar(Expression<Func<Habitacion, bool>> filtro = null);
    }
}
