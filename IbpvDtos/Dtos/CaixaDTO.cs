using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvDtos
{
    public class CaixaDTO
    {  
        public int? Id {get; set;}
        [Required(ErrorMessage = "nome é obrigatório")]
        public string? Nome {get; set;}
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "formato incorreto")]
        public decimal ValorTotal {get; set;}
    }
}