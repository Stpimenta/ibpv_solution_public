using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace c___Api_Example.Models
{
    public class CaixaModel
    {
        
        public int Id {get; set;}
        public string? Nome {get; set;}
        public decimal ValorTotal {get; set;}
        
        /* Relaçao com Gasto carrega uma collection de gasto representando o lado 0,n e possibilityando o acesso por propriedades.*/
        public ICollection<GastoModel>? Gastos {get;set;}
        public ICollection<ContribuicaoModel>? Contribuicoes {get;set;}
    
    }
}