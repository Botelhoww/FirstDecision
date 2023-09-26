using FirstDecision.Model.Entities;
using FluentValidation;

namespace FirstDecision.Business.Validators
{
    public class EmailValidator : AbstractValidator<Pessoa>
    {
        public EmailValidator()
        {
            RuleSet("EmailValidator", () =>
            {
                RuleFor(pessoa => pessoa.Email)
                    .EmailAddress()
                    .WithMessage("O e-mail informado não é válido");
            });
        }
    }
}