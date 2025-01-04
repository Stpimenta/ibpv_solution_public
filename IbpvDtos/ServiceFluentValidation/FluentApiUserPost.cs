using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using IbpvDtos.Enums;

namespace IbpvDtos.ServiceFluentValidation
{
    public class FluentApiUserPost:AbstractValidator<UsuarioPostDTO>
    {
        public FluentApiUserPost()
        {
            RuleFor(u => u.Email)
                    .NotEmpty().WithMessage("email não pode ser nulo")
                    .EmailAddress().WithMessage("endereço de email invalido");
        
            RuleFor(u => u.Nome)
                .Matches(@"^[a-zA-Z\s]*$").WithMessage("O nome não pode conter números ou símbolos.")
                .NotEmpty().WithMessage("nome não pode ser vazio");
                
                    
            RuleFor(u => u.Senha)
                .MinimumLength(6)
                .WithMessage("deve conter no minimo 6 caracteres");
            
            RuleFor(u => u.Cpf)
                .Must(ValidarCPF).WithMessage("cpf invalido");
            
            RuleFor(u => u.Data_nascimento)
                .NotEmpty().WithMessage("A data de nascimento não pode ser nula.")
                .Must(d => d < DateTime.Today).WithMessage("A data de nascimento deve estar no passado.");
            
            RuleFor(u => u.Telefone_pais)
                .NotEmpty().WithMessage("telefone país invalido, não pode ser nulo.");

            RuleFor(u => u.TelefoneDdd)
                .NotEmpty().WithMessage("telefone ddd invalido, não pode ser nulo.");

            RuleFor(u => u.TelefoneNumero)
                .NotEmpty().WithMessage("telefone numero invalido, não pode ser nulo.");

            RuleFor(u => u.BairroEdereco)
                .NotEmpty().WithMessage("endereço bairro inválido, não pode ser nulo.");

            RuleFor(u => u.CidadeEndereco)
                .NotEmpty().WithMessage("endereço cidade inválido, não pode ser nulo.");

            RuleFor(u => u.RuaEdereco)
                .NotEmpty().WithMessage("endereço rua inválido, não pode ser nulo.");

            RuleFor(u => u.CepEndereco)
                .NotEmpty().WithMessage("endereço cep inválido, não pode ser nulo.");

            RuleFor(u => u.NumeroEndereco)
                .NotEmpty().WithMessage("endereço numero inválido, não pode ser nulo.");

            RuleFor(u => u.UfEndereco)
                .NotEmpty().WithMessage("endereço estado inválido, não pode ser nulo.");

            RuleFor(u => u.Rule)
                .NotEmpty().WithMessage("regra inválida, não pode ser nulo")
                .Must(rule => Enum.IsDefined(typeof(EnumRule),rule)).WithMessage("regra inválida");
        }

        //validar cpf
         private bool ValidarCPF(string? cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
            return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for(int i=0; i<9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if ( resto < 2 )
                resto = 0;
            else
            resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for(int i=0; i<10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
            resto = 0;
            else
            resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}