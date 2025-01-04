
using IbpvDtos;
using c___Api_Example.Application.Services.UserCryptography;
using c___Api_Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace c___Api_Example.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        IServiceUserPassCryptography _iserviceUserPassCryptography;
        ServiceGenerateToken serviceGenerateToken;

        //password from firstuser appsettings
        string? rootuser;
        string? rootpass;

        public LoginController(IServiceUserPassCryptography serviceUserPassCryptography, ServiceGenerateToken serviceGenerateToken, IConfiguration configuration)
        {
            _iserviceUserPassCryptography = serviceUserPassCryptography;
            this.serviceGenerateToken = serviceGenerateToken;
            rootuser = configuration["AmbienteVar:user"];
            rootpass = configuration["AmbienteVar:password"];
        }

        [HttpPost]
        public async Task<ActionResult<RespondeLoginDto>> Login ([FromBody] LoginDTO login)
        {
            if(rootpass is not null && rootuser is not null)
            {
                if(login.gmail==rootuser && login.senha == rootpass)
                {
                    string Token = serviceGenerateToken.GenerateToken(0);
                    return Ok( new RespondeLoginDto {
                        status = true,
                        jwtToken = Token
                    });
                }
            }
                

            (bool compare, int id) serviceLogin = await _iserviceUserPassCryptography.comparePassUserLogin(login);
            
            if(serviceLogin.compare){
                string Token = serviceGenerateToken.GenerateToken(serviceLogin.id);
                return Ok( new RespondeLoginDto {
                    status = serviceLogin.compare,
                    jwtToken = Token
                });
            }
            
            return Unauthorized(new RespondeLoginDto {
                    status = serviceLogin.compare,
                    jwtToken = ""
                });
        }
    }
}