using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;


namespace IbpvFrontend.src.Provider
{
  
    public class UserAuthenticator : AuthenticationStateProvider
    {
        readonly private  ILocalStorageService _localStorageService;
       
        readonly private  ClaimsPrincipal _anonymus = new(new ClaimsIdentity ());
        public UserAuthenticator(ILocalStorageService localStorageService) 
        {
            _localStorageService = localStorageService;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token;

            try
            {
                token = await _localStorageService.GetItemAsync<string>("jwt");
            }
            catch (Exception)
            {
                
                // O armazenamento local não está disponível durante a pré-renderização
                return new AuthenticationState(_anonymus);
            }
            //verifico se o token existe
            if(string.IsNullOrEmpty(token))   return  new AuthenticationState(_anonymus);

            var getUserClaims = descriptaToken(token);
            if(getUserClaims == null) return new AuthenticationState(_anonymus);
            
            //criamos e retornamos a claim autenticada com id
            var ClaimsPrincipal = setClaimsPrincipal(getUserClaims);
            return await Task.FromResult(new AuthenticationState(ClaimsPrincipal));
            
        }

        //Oobjeto que representa a claims 
        public record CustomUserClaims(string Id = null!);
        public static ClaimsPrincipal  setClaimsPrincipal (CustomUserClaims claims)
        {
            //checamos se o id nele é nulo
            if(claims.Id is null)
                return  new ClaimsPrincipal();

            //se nao for criamos a claims
            return new ClaimsPrincipal(
                new ClaimsIdentity(
                    new List<Claim>
                    {
                        new(ClaimTypes.Sid, claims.Id)
                    },"jwtauth"));
        }


        private static CustomUserClaims descriptaToken (string jwt)
        {


            //verifica se jwt nao é nulo
            if(string.IsNullOrEmpty(jwt))
                return new CustomUserClaims();
            //instnacia um tokenhandler para descriptar
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            //decripto a validade
            var expiration  = token.Claims.FirstOrDefault(_ => _.Type == "exp");

            //verifico se o token ainda é valido
            //datetime offset classe        //fromunix metodo para converter unix seconds em um datimeoffset //utcdatetime para pegar a hora universal
            //converto para int pq e string o retorno value
            var expirationDateTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(expiration!.Value)).UtcDateTime;
            var dateNow = DateTime.UtcNow;

            if(expirationDateTime <= dateNow)
            {
                //retorno um vazio que vai resultar em um anonimo
                return new CustomUserClaims();
            }


            var id = token.Claims.FirstOrDefault(_ =>_.Type == ClaimTypes.Sid);
            return id == null ? null : new CustomUserClaims(id.Value);
        }

        public  void UpdateAuthenticationStateAsync(string jwt)
        {
            var getUserClaims = descriptaToken(jwt);
            if(getUserClaims == null) 
            {
                NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymus)));
                return;
            }
            
            var ClaimsPrincipal = setClaimsPrincipal(getUserClaims);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(ClaimsPrincipal)));
        }

    }
}


