using SistemaHotel.Client.Servicios.Contratos;
using SistemaHotel.Shared;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace SistemaHotel.Client.Servicios.Implementacion
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly HttpClient _http;
        public ClienteServicio(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<ClienteDTO>> Crear(ClienteDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/cliente/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ClienteDTO>>();
            return response!;
        }

        public async Task<bool> Editar(ClienteDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/cliente/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ClienteDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/cliente/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<ClienteDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ClienteDTO>>>("api/cliente/Lista");
            return result!;
        }
    }
}
