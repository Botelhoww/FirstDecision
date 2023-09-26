using FirstDecision.Business.Extensions;
using FluentValidation;

namespace FirstDecision.Business.Validators
{
    public class CpfCnpjValidator
    {
        public void Validate(string cpfCnpj)
        {
            if (!DocumentoExtensions.IsValidCpfOrCnpj(cpfCnpj))
            {
                throw new ValidationException("O campo CPF/CNPJ é inválido");
            }
        }
    }
}
