using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvFrontend.src.Components.Pages.Membro.form.model
{
    public class ModelEndereçoViaCep
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
    }
}