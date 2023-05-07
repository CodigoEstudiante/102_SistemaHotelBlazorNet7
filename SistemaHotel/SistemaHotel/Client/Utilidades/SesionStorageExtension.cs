using Blazored.SessionStorage;
using System.Text.Json;

namespace SistemaHotel.Client.Utilidades
{
    public static class SesionStorageExtension
    {
        public static async Task GuardarStorage<T>(
            this ISessionStorageService sessionStorageService,
            string key, T item
            ) where T : class
        {

            var itemJson = JsonSerializer.Serialize(item);
            await sessionStorageService.SetItemAsStringAsync(key, itemJson);

        }

        public static async Task<T?> ObtenerStorage<T>(
        this ISessionStorageService sessionStorageService,
        string key
        ) where T : class
        {
            var itemJson = await sessionStorageService.GetItemAsStringAsync(key);

            if (itemJson != null)
            {
                var item = JsonSerializer.Deserialize<T>(itemJson);
                return item;
            }
            else
                return null;
        }


    }
}
