using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvFrontend.src.Components.Pages.Membro.form.model
{
    public class ModelStep2
    {
        [Required(ErrorMessage="campo não pode ser nulo")]
        public  string? BairroEdereco {get; set;}
        [Required(ErrorMessage="campo não pode ser nulo")]
        public  string? CidadeEndereco {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public  string? RuaEdereco {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? CepEndereco {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? NumeroEndereco {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? UfEndereco {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? ComplementoEndereco {get; set;}
    }
}