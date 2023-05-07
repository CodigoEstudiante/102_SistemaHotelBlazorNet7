using SistemaHotel.Shared;

namespace SistemaHotel.Client.Servicios.Contratos
{
    public interface IRolUsuarioServicio
    {
        Task<ResponseDTO<List<RolUsuarioDTO>>> Lista();
    }
}
