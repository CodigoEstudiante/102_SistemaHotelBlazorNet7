using SistemaHotel.Server.Models;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Contratos
{
    public interface IPisoRepositorio
    {
        Task<List<Piso>> Lista();
        Task<Piso> Obtener(Expression<Func<Piso, bool>> filtro = null);
        Task<Piso> Crear(Piso entidad);
        Task<bool> Editar(Piso entidad);
        Task<bool> Eliminar(Piso entidad);
        Task<IQueryable<Piso>> Consultar(Expression<Func<Piso, bool>> filtro = null);
    }
}
