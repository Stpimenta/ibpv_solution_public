using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos.Enums;

namespace IbpvDtos
{
    public class UsuarioPutDTO
    {
        public string? Nome {get; set;}
        public string? Email {get; set;}
        public string? Cpf {get; set;}
        public string? TokenContribuicao {get; set;}
        public string?  RGEmissor{get; set;}
        public string? RGnumero{get; set;}
        public string? Telefone_pais {get; set;}
        public string? TelefoneDdd {get; set;}
        public string? TelefoneNumero {get; set;}
        public string? BairroEdereco {get; set;}
        public string? CidadeEndereco {get; set;}
        public string? RuaEdereco {get; set;}
        public string? CepEndereco {get; set;}
        public string? NumeroEndereco {get; set;}
        public string? UfEndereco {get; set;}
        public DateTime? Data_nascimento {get; set;}
        public bool? Active {get; set;}
        public EnumRule? Rule{get; set;}
    }
}