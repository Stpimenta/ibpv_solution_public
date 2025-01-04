using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;

namespace IbpvFrontend.src.Provider.interfaces
{
    public interface IProviderUserLogin
    {
        public Task<RespondeLoginDto> Login(LoginDTO loginDTO);
    }
}