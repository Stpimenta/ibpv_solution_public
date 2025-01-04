using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using IbpvFrontend.src.Provider.interfaces;

namespace IbpvFrontend.src.Provider
{
    public class ProviderUserLogin : IProviderUserLogin
    {
        readonly private IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;

        public ProviderUserLogin(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("IbpvApi");
        }

        public async Task<RespondeLoginDto> Login(LoginDTO loginDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Login", loginDTO);

            //se o status code nao for 200 retornar como nulo e tratar error no front
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new RespondeLoginDto
                {
                    status = false,
                    jwtToken = ""
                };
            }
            
            //descerializar o objeto com dto compartilhado
            var deserializedObject = await response.Content.ReadFromJsonAsync<RespondeLoginDto>();
            return new RespondeLoginDto
            {
                status = deserializedObject!.status, 
                jwtToken = deserializedObject!.jwtToken 
            };
        }
    }
}