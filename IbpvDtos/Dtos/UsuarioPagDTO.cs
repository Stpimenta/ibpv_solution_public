using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos.Enums;

namespace IbpvDtos
{
    public class UsuarioPagDTO
    {
        public int Id {get; set;}
        public string? Nome {get; set;}
        public string? Email {get; set;}
        public string? TokenContribuicao {get; set;}
        public DateTime Data_nascimento {get; set;}
        public EnumStatusMembro status {get; set;}

    }
}