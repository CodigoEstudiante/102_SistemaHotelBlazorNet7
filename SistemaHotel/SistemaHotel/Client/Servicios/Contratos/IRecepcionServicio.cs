using SistemaHotel.Shared;

namespace SistemaHotel.Client.Servicios.Contratos
{
    public interface IRecepcionServicio
    {
        Task<ResponseDTO<RecepcionDTO>> Obtener(int idHabitacion);
        Task<ResponseDTO<RecepcionDTO>> Crear(RecepcionDTO entidad);
        Task<bool> Editar(RecepcionDTO entidad);
        Task<ResponseDTO<List<ReporteDTO>>> Reporte(string fechaInicio, string fechaFin);
    }
}
