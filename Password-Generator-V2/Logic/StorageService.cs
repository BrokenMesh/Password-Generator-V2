using Microsoft.JSInterop;
using System.Text.Json;

namespace Password_Generator_V2.Logic
{
    public class StorageService
    {
        private readonly IJSRuntime jsRuntime;

        public StorageService(IJSRuntime _jSRuntime) {
            jsRuntime = _jSRuntime;
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            var jsonValue = JsonSerializer.Serialize(value);
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", key, jsonValue);
        }

        public async Task<T?> GetItemAsync<T>(string key)
        {
            var jsonValue = await jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return jsonValue is not null ? JsonSerializer.Deserialize<T>(jsonValue) : default;
        }

        public async Task RemoveItemAsync(string key)
        {
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public async Task ClearAsync()
        {
            await jsRuntime.InvokeVoidAsync("localStorage.clear");
        }
    }
}
