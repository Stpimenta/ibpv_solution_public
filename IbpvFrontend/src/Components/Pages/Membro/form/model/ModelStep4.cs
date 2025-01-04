using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos.Enums;

namespace IbpvFrontend.src.Components.Pages.Membro.form.model
{
    public class ModelStep4
    {
        public DateTime? dataBatismo {get; set;}
        public string? pastorBatismo {get; set;}
        public string? igrejaBatismo {get; set;}
        
        [Required(ErrorMessage="campo não pode ser nulo")]
        public EnumRule? Rule{get; set;}

    }
}