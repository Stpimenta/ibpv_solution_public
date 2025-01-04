using FluentValidation;
using IbpvDtos;

public class PersonValidator : AbstractValidator<CaixaDTO>
{
    public PersonValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage("nome do caixa é obrigatório");
        RuleFor(c => c.ValorTotal).NotNull().WithMessage("valor não pode ser nulo.");
        // Adicione outras regras de validação conforme necessário
    }
}
