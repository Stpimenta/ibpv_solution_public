using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos.Enums;
using IbpvDtos.personvalidations;

namespace IbpvFrontend.src.Components.Pages.Membro.form.model
{
    public class ModelStep3
    {
        public string? Cpf {get; set;}
        public string? TokenContribuicao {get; set;}
        public string? RGnumero{get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        [DataPersonFutureValidation(ErrorMessage = "A data não pode estar no futuro.")]
        public DateTime? Data_nascimento {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? filhos {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? profissao {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? estadoCivil {get; set;}

        
        [Required(ErrorMessage="campo não pode ser nulo")]        
        public Enumgenero? genero {get;set;}

    }
}