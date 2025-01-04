using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using Microsoft.AspNetCore.Components.Authorization;
namespace IbpvFrontend.src.Services.UserServices
{
    public interface ILoginService
    {
        public Task<Boolean> login (LoginDTO loginDTO);
        public Task<AuthenticationState> getUserLoginState ();

        public Task<string> getJwtToken ();

        public Task exitSesion();
    }

}