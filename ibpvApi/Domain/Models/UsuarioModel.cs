using System.Collections.ObjectModel;
using c___Api_Example.Domain.Models;
using IbpvDtos.Enums;


/* model é um molde do que a entidade faz no sistema de suas caracteristicas e ações, mas sem implementações*/
namespace c___Api_Example.Models
{
    public class UsuarioModel
    {
        /*compilador cria {get; set;}*/
        public int Id {get; set;}
        public string? Nome {get; set;}
        public string? Email {get; set;}
        public string? Senha {get; set;}
        public string? Cpf {get; set;}
        public string? TokenContribuicao {get; set;}
        public string? RGnumero{get; set;}
        public string? Telefone_pais {get; set;}
        public string? TelefoneNumero {get; set;}
        public string? BairroEdereco {get; set;}
        public string? CidadeEndereco {get; set;}
        public string? RuaEdereco {get; set;}
        public string? CepEndereco {get; set;}
        public string? NumeroEndereco {get; set;}
        public string? UfEndereco {get; set;}
        public string? ComplementoEndereco {get; set;}
        public DateTime? Data_nascimento {get; set;}
        public DateTime? dataBatismo {get; set;}
        public string? pastorBatismo {get; set;}
        public string? igrejaBatismo {get; set;}
        public bool filhos {get; set;}
        public string? profissao {get; set;}
        public string? estadoCivil {get; set;}
        
        public EnumStatusMembro status {get; set;}
        public EnumRule? Rule{get; set;}
        public Collection<ContribuicaoModel>? Contribuicao;
        public Collection<DesligamentoModel>? HistDesligamento;
        public Enumgenero? genero {get;set;}
        public string? urlImage {get;set;}

        /*programador  cria*/
        //  public string nome
        // {
        //     get { return nome; }
        //     set { nome = value; }
        // }
    }
}