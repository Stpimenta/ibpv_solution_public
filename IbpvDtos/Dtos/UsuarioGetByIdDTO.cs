using System.Collections.ObjectModel;
using IbpvDtos.Enums;
namespace IbpvDtos
{
    public class UsuarioGetByIdDTO
    {
       
        public int Id {get; set;}
        public string? Nome {get; set;}
        public string? Email {get; set;}
        public string? Cpf {get; set;}
        public string? TokenContribuicao {get; set;}
        public string? RGnumero{get; set;}
        public string? Telefone_pais {get; set;}
        public string? TelefoneNumero {get; set;}
        public string? BairroEdereco {get; set;}
        public string? CidadeEndereco {get; set;}
        public required string RuaEdereco {get; set;}
        public required string CepEndereco {get; set;}
        public required string NumeroEndereco {get; set;}
        public string? UfEndereco {get; set;}
         public string? ComplementoEndereco {get; set;}
        public DateTime Data_nascimento {get; set;}
        public DateTime? dataBatismo {get; set;}
        public string? pastorBatismo {get; set;}
        public string? igrejaBatismo {get; set;}
        public bool filhos {get; set;}
        public string? profissao {get; set;}
        public string? estadoCivil {get; set;}
        public bool? Active {get; set;}
        public EnumRule? Rule{get; set;}
        public Enumgenero? genero {get;set;}
    }
}