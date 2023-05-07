using SistemaHotel.Client.Servicios.Contratos;
using SistemaHotel.Shared;
using System.Net.Http.Json;

namespace SistemaHotel.Client.Servicios.Implementacion
{
    public class PisoServicio : IPisoServicio
    {
        private readonly HttpClient _http;
        public PisoServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<PisoDTO>> Crear(PisoDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/piso/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<PisoDTO>>();
            return response!;
        }

        public async Task<bool> Editar(PisoDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/piso/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<PisoDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/piso/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<PisoDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<PisoDTO>>>("api/piso/Lista");
            return result!;
        }
    }
}
