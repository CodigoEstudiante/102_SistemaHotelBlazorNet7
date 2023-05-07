using SistemaHotel.Client.Servicios.Contratos;
using SistemaHotel.Shared;
using System.Net.Http.Json;

namespace SistemaHotel.Client.Servicios.Implementacion
{
    public class DashBoardServicio : IDashBoardServicio
    {
        private readonly HttpClient _http;
        public DashBoardServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<DashBoardDTO>> Resumen()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<DashBoardDTO>>($"api/dashboard/Resumen");
            return result!;
        }
    }
}
