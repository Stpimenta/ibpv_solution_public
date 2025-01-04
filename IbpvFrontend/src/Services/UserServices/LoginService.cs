using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using IbpvDtos;
using IbpvFrontend.src.Provider;
using IbpvFrontend.src.Provider.interfaces;
using Microsoft.AspNetCore.Components.Authorization;


namespace IbpvFrontend.src.Services.UserServices
{
    public class LoginService : ILoginService
    {
        readonly private IProviderUserLogin _providerUserLogin;

        readonly private AuthenticationStateProvider _authenticationStateProvider;
        readonly private ILocalStorageService _localStorageService;

        public LoginService(IProviderUserLogin providerUserLogin, ILocalStorageService localStorageService, AuthenticationStateProvider stateProvider)
        {
            _authenticationStateProvider = stateProvider;
            _providerUserLogin = providerUserLogin;
            _localStorageService = localStorageService;
        }

        public async Task<bool> login (LoginDTO loginDTO)
        {
           
            RespondeLoginDto objectlogin = await _providerUserLogin.Login(loginDTO);

            if(objectlogin.status)
            {
                //coloco o jwt no l;ocal Storage
                await _localStorageService.SetItemAsync("jwt",objectlogin.jwtToken);
                var authProvider = (UserAuthenticator)_authenticationStateProvider;
                
                if (string.IsNullOrEmpty(objectlogin.jwtToken))
                    return false;
                //atualizo o status de Autorizaçao do sistema
                authProvider.UpdateAuthenticationStateAsync(objectlogin.jwtToken);
                return true;
            }
            return false;
        }

        //verificar se o usuario esta autenticado
        public async Task<AuthenticationState> getUserLoginState ()
        {
            var authProvider = (UserAuthenticator)_authenticationStateProvider;
            var state = await authProvider.GetAuthenticationStateAsync();
            return state;
        }

        public async Task<string> getJwtToken ()
        {
            string? token;
            try
            {
                return token = await _localStorageService.GetItemAsync<string>("jwt");
            }
            catch (Exception)
            {
                // O armazenamento local não está disponível durante a pré-renderização
                return "";
            }
        }
        
        public async Task exitSesion ()
        {
            //coloco o jwt no l;ocal Storage
            await _localStorageService.RemoveItemAsync("jwt");
            
        }

    }
}