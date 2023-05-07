using SistemaHotel.Shared;

namespace SistemaHotel.Client.Servicios.Contratos
{
    public interface IPisoServicio
    {
        Task<ResponseDTO<List<PisoDTO>>> Lista();
        Task<ResponseDTO<PisoDTO>> Crear(PisoDTO entidad);
        Task<bool> Editar(PisoDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
