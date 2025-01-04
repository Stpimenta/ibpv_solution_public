using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c___Api_Example.Models
{
    public class ContribuicaoModel
    {
        public int Id {get;set;}
        public decimal Valor {get;set;}
        public string? Descricao {get;set;}
        public DateTime Data {get;set;}
        public string? UrlEnvelope {get;set;}

        /*relacionamento com caixa*/
        public int IdCaixa {get;set;}
        public CaixaModel? Caixa { get; set; }

        public int? IdMembro {get; set;}
        public UsuarioModel? Membro {get; set;}

    }
}