using SistemaHotel.Shared;

namespace SistemaHotel.Client.Servicios.Contratos
{
    public interface IClienteServicio
    {
        Task<ResponseDTO<List<ClienteDTO>>> Lista();
        Task<ResponseDTO<ClienteDTO>> Crear(ClienteDTO entidad);
        Task<bool> Editar(ClienteDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
