using SistemaHotel.Server.Models;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Contratos
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> Lista();
        Task<Cliente> Obtener(Expression<Func<Cliente, bool>> filtro = null);
        Task<Cliente> Crear(Cliente entidad);
        Task<bool> Editar(Cliente entidad);
        Task<bool> Eliminar(Cliente entidad);
        Task<IQueryable<Cliente>> Consultar(Expression<Func<Cliente, bool>> filtro = null);
    }
}
