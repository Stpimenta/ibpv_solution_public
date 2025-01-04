using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c___Api_Example.Models
{
    public class GastoModel
    {
        public int Id {get;set;}
        public decimal Valor {get;set;}
        public string? Descricao {get;set;}
        public DateTime Data {get;set;}
        public string? UrlComprovante {get;set;}
        public string? NumeroFiscal {get;set;}


        /* relacionamento carrega o id do caixa correpondente e um caixa para acessar as propriedades do Caixa */
        public int IdCaixa {get;set;}
        public CaixaModel? Caixa { get; set; }
    }
}