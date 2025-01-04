using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos.personvalidations;

namespace IbpvDtos
{
    public class DtoGastoPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor não pode ser nulo")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string? Descricao { get; set; } 

        [Required(ErrorMessage = "Data é obrigatória")]
        [DataPersonFutureValidation(ErrorMessage = "data futura não permitida")]
        public DateTime? Data { get; set; }

        public string? UrlComprovante { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de caracteres atingido")]
        public string? NumeroFiscal { get; set; }

        [Required(ErrorMessage = "É necessário vínculo com um caixa")]
        public int? IdCaixa { get; set; }
    }
}