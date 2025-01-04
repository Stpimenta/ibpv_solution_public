using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;
using IbpvDtos;
using c___Api_Example.data;
using c___Api_Example.Models;
using c___Api_Example.repository;
using c___Api_Example.repository.Interfaces;

namespace c___Api_Example.Application.Services.UserCryptography
{
    public class ServiceUserPassCryptography : IServiceUserPassCryptography
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public ServiceUserPassCryptography(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<(bool,int)> comparePassUserLogin(LoginDTO credentials)
        {   
            UsuarioModel? user = await _usuarioRepositorio.GetUserByGmail(credentials.gmail);
            if(user is null)
            {
                return (false,0);
            }
            bool compare = BCrypt.Net.BCrypt.Verify(credentials.senha,user.Senha);

            if(compare)
            {
                return (compare,user.Id);
            }

            return (false,0);
        }

        public string encryptPassUser(string pass)
        {
            return BCrypt.Net.BCrypt.HashPassword(pass);
        }
    }
}