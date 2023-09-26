using FirstDecision.Business.Validators;
using FirstDecision.Model.Entities;
using FluentValidation;

namespace FirstDecision.Tests
{
    public class EmailTest
    {
        [Test]
        [Description("Testa um Email válido")]
        [TestCase("emailvalido@dominio.com")]
        public void Deve_Validar_Email_Corretamente(string email)
        {
            // Arrange
            var emailValidator = new EmailValidator();
            var pessoa = new Pessoa { Email = email };

            // Act
            var resultado = emailValidator.Validate(pessoa, options =>
            {
                options.IncludeRuleSets("EmailValidator");
            });

            // Assert
            Assert.IsTrue(resultado.IsValid);
        }

        [Test]
        [Description("Testa um Email inválido")]
        [TestCase("string")]
        public void Nao_Deve_Permitir_Email_Invalido(string email)
        {
            // Arrange
            var emailValidator = new EmailValidator();
            var pessoa = new Pessoa { Email = email };

            // Act
            var ex = Assert.Throws<ValidationException>(() => emailValidator.Validate(pessoa, options =>
            {
                options.ThrowOnFailures();
                options.IncludeRuleSets("EmailValidator");
            }));

            // Assert
            Assert.IsTrue(ex.Message.Contains("O e-mail informado não é válido"));
        }
    }
}
