using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c___Api_Example.Application.Services.GeneratedUserToken
{
    public class ServiceGeneratedUserToken : IServiceGeneratedUserToken
    {
        public string generateUserToken36(int lengthToken)
        {
            Random random = new Random();
            string token = "";
            for (int i=0; i<lengthToken; i++){

                //gera um random
                int num = random.Next(0,36);

                //se for menor que dez se encaixa nos digitos da tabela ascii
                if(num < 10)
                {
                  token += (char)(num+48);
                }

                else
                {
                    token += (char)(num+87);
                }
            }
            return token.ToUpper();
        }
    }
}