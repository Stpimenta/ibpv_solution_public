using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos.Enums;
using IbpvDtos.personvalidations;


namespace IbpvDtos
{
    public class UsuarioPostDTO
    {
        [Required(ErrorMessage="insira um nome")]
        [MinLength(6,ErrorMessage = "insira seu nome completo")]
        public string? Nome {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string? Email {get; set;}
        
        [Required(ErrorMessage="campo não pode ser nulo")]
        [RegularExpression(@"^(?=.*[!@#$%^&*()_+{}[\]:;<>,.?/~])[\w!@#$%^&*()_+{}[\]:;<>,.?/~]{6,}$",
        ErrorMessage = "senha muito fraca, utilize caracteres especiais")]
        public string? Senha {get; set;}
        
        public string? Cpf {get; set;}
        public string? TokenContribuicao {get; set;}
        public string? RGnumero{get; set;}
        public string? Telefone_pais {get; set;}
        public string? TelefoneNumero {get; set;}

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
        
        public string? ComplementoEndereco {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        [DataPersonFutureValidation]
        public DateTime? Data_nascimento {get; set;}

        public DateTime? dataBatismo {get; set;}
        public string? pastorBatismo {get; set;}
        public string? igrejaBatismo {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public bool filhos {get; set;}
        
        public string? profissao {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public string? estadoCivil {get; set;}
        
        [Required(ErrorMessage="campo não pode ser nulo")]
        public EnumStatusMembro status {get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public EnumRule? Rule{get; set;}

        [Required(ErrorMessage="campo não pode ser nulo")]
        public Enumgenero? genero {get;set;}

        public string? urlImage {get;set;}

    }
}