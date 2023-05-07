using SistemaHotel.Server.Models;

namespace SistemaHotel.Server.Repositorio.Contratos
{
    public interface IRolUsuarioRepositorio
    {
        Task<List<RolUsuario>> Lista();
    }
}
