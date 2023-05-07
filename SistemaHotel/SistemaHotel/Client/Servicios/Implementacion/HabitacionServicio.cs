using SistemaHotel.Client.Servicios.Contratos;
using SistemaHotel.Shared;
using System.Net.Http.Json;

namespace SistemaHotel.Client.Servicios.Implementacion
{
    public class HabitacionServicio : IHabitacionServicio
    {
        private readonly HttpClient _http;
        public HabitacionServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<HabitacionDTO>> Crear(HabitacionDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/habitacion/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<HabitacionDTO>>();
            return response!;
        }

        public async Task<bool> Editar(HabitacionDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/habitacion/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<HabitacionDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/habitacion/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<HabitacionDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<HabitacionDTO>>>("api/habitacion/Lista");
            return result!;
        }

        public async Task<ResponseDTO<HabitacionDTO>> Obtener(int idHabitacion)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<HabitacionDTO>>($"api/habitacion/Obtener/{idHabitacion}");
            return result!;
        }
    }
}
