using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IbpvFrontend.src.Components.Pages.Membro.form.model
{
    public class ModelStep1
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

        [Required(ErrorMessage="campo não pode ser nulo")]
        [Compare(nameof(Senha), ErrorMessage = "As senhas não coincidem.")]
        public string? ConfirmarSenha { get; set; }
        public string? Telefone_pais {get; set;}
        
        public string? TelefoneNumero {get; set;}
    }
}