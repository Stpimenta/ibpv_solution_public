using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using IbpvFrontend.src.Services.UserServices;

namespace IbpvFrontend.src.Services
{
    public class CostumerHttpCLient : HttpClient
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAcessor;
        private readonly ILoginService _loginService;
        public CostumerHttpCLient(IHttpContextAccessor httpContextAcessor, ILoginService loginService, IConfiguration configuration)
        {
            _httpContextAcessor = httpContextAcessor;
            _loginService = loginService;
            _configuration = configuration;
            BaseAddress = new Uri(_configuration["AmbienteVar:databaseApiEndpoint"]!);
             // Configure o HttpClient para incluir automaticamente o cabeçalho de autorização
        }

        public async Task configureHeaders ()
        {
            var jwt = await  _loginService.getJwtToken();

        
            if(!string.IsNullOrEmpty(jwt))
            {   
                DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
            }
            else
            {
                throw new Exception("jwt token is null costumer client");
            }
       
        }
    }
}