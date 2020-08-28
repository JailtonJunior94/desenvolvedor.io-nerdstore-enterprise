using System.Text;
using System.Net.Http;
using System.Text.Json;
using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var response = await _httpClient.PostAsync("https://localhost:44351/api/identidade/autenticar", loginContent);
            var content = await response.Content.ReadAsStringAsync();

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin { ResponseResult = JsonSerializer.Deserialize<ResponseResult>(content, options) };
            }

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(content, options);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44351/api/identidade/nova-conta", registroContent);
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<UsuarioRespostaLogin>(content, options);
        }
    }
}
