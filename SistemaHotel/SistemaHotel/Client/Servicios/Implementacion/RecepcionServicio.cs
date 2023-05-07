using SistemaHotel.Client.Servicios.Contratos;
using SistemaHotel.Shared;
using System.Net.Http.Json;

namespace SistemaHotel.Client.Servicios.Implementacion
{
    public class RecepcionServicio : IRecepcionServicio
    {

        private readonly HttpClient _http;
        public RecepcionServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<RecepcionDTO>> Crear(RecepcionDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/recepcion/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<RecepcionDTO>>();
            return response!;
        }

        public async Task<bool> Editar(RecepcionDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/recepcion/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<RecepcionDTO>>();

            return response!.status;
        }

        public async Task<ResponseDTO<RecepcionDTO>> Obtener(int idHabitacion)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<RecepcionDTO>>($"api/recepcion/Obtener/{idHabitacion}");
            return result!;
        }

        public async Task<ResponseDTO<List<ReporteDTO>>> Reporte(string fechaInicio, string fechaFin)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ReporteDTO>>>($"api/recepcion/Reporte?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }
    }
}
