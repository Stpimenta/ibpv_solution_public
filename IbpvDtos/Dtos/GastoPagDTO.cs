using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvDtos
{
    public class GastoPagDTO
    {
        public int Id {get;set;}
        public decimal Valor {get;set;}
        public string? Descricao {get;set;}
        public DateTime Data {get;set;}
        public string? UrlComprovante {get;set;}
        public string? NumeroFiscal {get;set;}
        public string? Caixa {get; set;}

    }
}