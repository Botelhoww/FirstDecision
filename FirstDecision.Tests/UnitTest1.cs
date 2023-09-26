using FirstDecision.Business.Validators;
using FirstDecision.Model.Entities;
using FirstDecision.Business.Extensions;
using FluentValidation;

namespace FirstDecision.Tests
{
    public class Tests
    {
        [Test]
        public void Deve_Criar_Pessoa_Corretamente()
        {
            // Arrange
            var pessoa = new Pessoa
            {
                Cep = "12345678",
                CpfCnpj = "12345678901",
                Email = "vbawada@firstdecision.com.br",
                Nome = "Vinicius Botelho",
                Sobrenome = "Awada",
                Telefone = "11969728877",
                Cidade = "São Paulo",
                Estado = "SP",
                DataNascimento = DateTime.Now.AddYears(-23),
                Endereco = "Rua dos Testes, 123"
            };

            // Act
            var pessoaValidator = new PessoaValidator();
            var resultado = pessoaValidator.Validate(pessoa);

            // Assert
            Assert.IsTrue(resultado.IsValid);
        }

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

        [Test]
        [Description("Testa um CPF e CNPJ válido")]
        [TestCase("37709475841")]
        [TestCase("06898464000143")]
        public void Deve_Validar_CPFCNPJ_Corretamente(string cpfcnpj)
        {
            // Act
            var isValid = DocumentoExtensions.IsValidCpfOrCnpj(cpfcnpj);

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        [Description("Testa um CPF e CNPJ inválido")]
        [TestCase("31231231231")]
        [TestCase("3812738912731")]
        public void Nao_Deve_Permitir_CPFCNPJ_Invalido(string cpfcnpj)
        {
            // Act
            var isValid = DocumentoExtensions.IsValidCpfOrCnpj(cpfcnpj);

            Console.WriteLine(isValid);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}