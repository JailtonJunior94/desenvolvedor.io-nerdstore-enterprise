﻿using System.Net.Http;
using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;
using NSE.WebApp.MVC.Extensions;
using Microsoft.Extensions.Options;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;

        public AutenticacaoService(HttpClient httpClient,
                                   IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);
            var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}/api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
                return new UsuarioRespostaLogin { ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response) };

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);
            var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
                return new UsuarioRespostaLogin { ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response) };

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
