using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Npgsql.Internal;

namespace c___Api_Example.Services
{
    public class ServiceGenerateToken
    {
        private readonly string jwt_key;

        public ServiceGenerateToken(IConfiguration configuration)
        {
            string? key = configuration["AmbienteVar:jwt"];

            if(key is not null)
            {
                jwt_key = key;
            }
            else
            {
                throw new Exception("key jwt in ambiente var is null");
            }
        }

        public string GenerateToken(int id){
            var key = Encoding.ASCII.GetBytes(jwt_key); // transforma fazx um encondig da string para um array de bytes

            var securitykey = new SymmetricSecurityKey(key); //chave
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);

            //o que vai de informacao no token Claim
            var userClaims = new[]
            {
                new Claim(ClaimTypes.Sid , id.ToString())
            };
            
            //configuraçoes
            var tokenConfig = new JwtSecurityToken
            (
                // issuer: 
                // audience:
                claims:userClaims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenConfig);
        }
    }
}