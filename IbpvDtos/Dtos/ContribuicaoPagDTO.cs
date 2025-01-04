using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvDtos
{
    public class ContribuicaoPagDTO
    {
        public int Id {get;set;}
        public decimal Valor {get;set;}
        public string? Descricao {get;set;}
        public DateTime Data {get;set;}
        public string? UrlEnvelope {get;set;}
        public string? Caixa {get;set;}
        public string? TokenMembro {get; set;}
    }
}