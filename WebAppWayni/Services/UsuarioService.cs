using System.Text;
using System.Text.Json;
using WebAppWayni.Models;
using WebAppWayni.Services.Interfaces;

namespace WebAppWayni.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl; 

        public UsuarioService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiSettings:UsuarioServiceUrl"];
        }

        public async Task<bool> GetExisteDNIAsync(string dni,Guid? id)
        {
            string requestUri = $"{_apiUrl}/ExisteDNI/{dni}";
            if(id != null)
            {
                requestUri = requestUri + $"?id={id}";
            }
            var response = await _httpClient.GetAsync(requestUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al validar el DNI.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var existe = JsonSerializer.Deserialize<bool>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return existe;
        }

        public async Task<Usuario> GetUsuarioAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al obtener los usuarios.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var usuario = JsonSerializer.Deserialize<Usuario>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return usuario;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            var response = await _httpClient.GetAsync(_apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al obtener los usuarios.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var usuarios = JsonSerializer.Deserialize<List<Usuario>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return usuarios;
        }

        public async Task<bool> PostUsuarioAsync(Usuario usuario)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(_apiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al crear el usuario.");
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutUsuarioAsync(Guid id, Usuario usuario)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(usuario),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}/{id}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al actualizar el usuario.");
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUsuarioAsync(Guid id)
        {
            
            var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al eliminar el usuario.");
            }

            return response.IsSuccessStatusCode;
        }
    }
}
