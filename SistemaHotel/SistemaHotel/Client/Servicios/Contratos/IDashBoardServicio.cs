using SistemaHotel.Shared;

namespace SistemaHotel.Client.Servicios.Contratos
{
    public interface IDashBoardServicio
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
