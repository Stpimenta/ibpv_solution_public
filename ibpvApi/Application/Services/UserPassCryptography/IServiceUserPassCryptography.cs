using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;

namespace c___Api_Example.Application.Services.UserCryptography
{
    public interface IServiceUserPassCryptography
    {
        string encryptPassUser(string pass);
        Task<(bool,int)> comparePassUserLogin(LoginDTO credentials);
    }
}