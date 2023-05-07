using SistemaHotel.Server.Models;
using System.Linq.Expressions;

namespace SistemaHotel.Server.Repositorio.Contratos
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Lista();
        Task<Categoria> Obtener(Expression<Func<Categoria, bool>> filtro = null);
        Task<Categoria> Crear(Categoria entidad);
        Task<bool> Editar(Categoria entidad);
        Task<bool> Eliminar(Categoria entidad);
        Task<IQueryable<Categoria>> Consultar(Expression<Func<Categoria, bool>> filtro = null);
    }
}
