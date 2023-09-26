using FirstDecision.Business.Extensions;
using FirstDecision.Business.Services;
using FirstDecision.Business.Validators;
using FirstDecision.DataLayer.Repositories.Interfaces;
using FirstDecision.Model.Entities;
using FluentValidation;
using Moq;

namespace FirstDecision.Tests
{
    public class PessoaTest
    {
        private Mock<IPessoaRepository> _mockPessoaRepository;
        private PessoaService _pessoaService;

        [SetUp]
        public void Setup()
        {
            _mockPessoaRepository = new Mock<IPessoaRepository>();
            _pessoaService = new PessoaService(_mockPessoaRepository.Object, new PessoaValidator());
        }

        [Test]
        [Description("Testa uma alteração nos dados da pessoa com algum dado inválido")]
        [TestCase("12345678900")]
        public void Alterar_DeveLancarExcecaoParaDadosInvalidos(string cep)
        {
            // Arrange
            var pessoa = ObterPessoaValida();
            pessoa.Cep = cep;

            // Act & Assert
            Assert.ThrowsAsync<ValidationException>(() => _pessoaService.Alterar(pessoa));
        }

        [Test]
        [Description("Testa uma inclusão nos dados da pessoa com algum dado inválido")]
        [TestCase("12345678900")]
        public void Incluir_DeveLancarExcecaoParaDadosInvalidos(string cep)
        {
            // Arrange
            var pessoa = ObterPessoaValida();
            pessoa.Cep = cep;

            // Act & Assert
            Assert.ThrowsAsync<ValidationException>(() => _pessoaService.Incluir(pessoa));
        }

        [Test]
        public void Deve_Criar_Pessoa_Corretamente()
        {
            // Arrange
            var pessoa = ObterPessoaValida();

            // Act
            var pessoaValidator = new PessoaValidator();
            var resultado = pessoaValidator.Validate(pessoa);

            // Assert
            Assert.IsTrue(resultado.IsValid);
        }

        [Test]
        public async Task Incluir_DeveIncluirPessoaCorretamente()
        {
            // Arrange
            var pessoa = ObterPessoaValida();

            // Act
            await _pessoaService.Incluir(pessoa);

            // Assert
            _mockPessoaRepository.Verify(repo => repo.Incluir(pessoa), Times.Once);
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

        [Test]
        public async Task GetAll_DeveRetornarTodasAsPessoas()
        {
            // Arrange
            var pessoas = new List<Pessoa> { ObterPessoaValida(), ObterPessoaValida() };
            _mockPessoaRepository.Setup(repo => repo.GetAll()).ReturnsAsync(pessoas);

            // Act
            var result = await _pessoaService.GetAll();

            // Assert
            Assert.AreEqual(pessoas, result);
        }

        [Test]
        public async Task GetById_DeveRetornarPessoaCorreta()
        {
            // Arrange
            var pessoa = ObterPessoaValida();
            _mockPessoaRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(pessoa);

            // Act
            var result = await _pessoaService.GetById(1);

            // Assert
            Assert.AreEqual(pessoa, result);
        }

        private Pessoa ObterPessoaValida()
        {
            return new Pessoa
            {
                Cep = "12345678",
                CpfCnpj = "92018200038", //cpf
                Email = "vbawada@firstdecision.com.br",
                Nome = "Vinicius Botelho",
                Sobrenome = "Awada",
                Telefone = "11969721122",
                Cidade = "São Paulo",
                Estado = "SP",
                DataNascimento = DateTime.Now.AddYears(-23),
                Endereco = "Rua dos Testes, 123"
            };
        }
    }
}