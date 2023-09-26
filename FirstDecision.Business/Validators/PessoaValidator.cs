using FirstDecision.Model.Entities;
using FluentValidation;

namespace FirstDecision.Business.Validators
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleSet("PessoaValidator", () =>
            {
                RuleFor(p => p.Nome)
                    .NotEmpty()
                    .WithMessage("Nome é obrigatório");

                RuleFor(p => p.Email)
                    .NotEmpty()
                    .WithMessage("Email é obrigatório");

                RuleFor(p => p.Telefone)
                    .MaximumLength(20)
                    .WithMessage("Telefone deve ter no máximo 20 caracteres");

                RuleFor(p => p.Cidade)
                    .MaximumLength(100)
                    .WithMessage("Cidade deve ter no máximo 100 caracteres");

                RuleFor(p => p.Estado)
                    .MaximumLength(50)
                    .WithMessage("Estado deve ter no máximo 50 caracteres");

                RuleFor(p => p.Cep)
                .MaximumLength(10)
                    .WithMessage("CEP deve ter no máximo 10 caracteres");

                RuleFor(p => p.Cpf)
                .MaximumLength(11)
                    .WithMessage("CPF deve ter no máximo 11 caracteres");

                RuleFor(p => p.Cnpj)
                .MaximumLength(14)
                    .WithMessage("CNPJ deve ter no máximo 14 caracteres");
            });
        }
    }
}