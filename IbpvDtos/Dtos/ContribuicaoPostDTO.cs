using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos.personvalidations;

namespace IbpvDtos
{
    public class ContribuicaoPostDTO
    {
        public int Id {get;set;}
        
        [Required(ErrorMessage = "Valor não pode ser nulo")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser maior que zero")]
        public decimal Valor {get;set;}
        public string? Descricao {get;set;}
        
        [Required(ErrorMessage = "data não pode ser nulo")]
        [DataPersonFutureValidation(ErrorMessage = "data futura não permitida")]
        public DateTime? Data {get;set;}
        public string? UrlEnvelope {get;set;}
        /*relacionamento com caixa*/
        
        [Required(ErrorMessage = "selecione um caixa")]
        public int? IdCaixa {get;set;}
        public int? IdMembro {get; set;}
     
    }
}