using FirstDecision.Business.Extensions;
using FirstDecision.Business.Services.Interfaces;
using FirstDecision.Business.Validators;
using FirstDecision.DataLayer.Repositories.Interfaces;
using FirstDecision.Model.Entities;
using FluentValidation;

namespace FirstDecision.Business.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IValidator<Pessoa> _pessoaValidator;
        private readonly CpfCnpjValidator _cpfCnpjValidator;

        public PessoaService(IPessoaRepository pessoaRepository, IValidator<Pessoa> pessoaValidator, CpfCnpjValidator cpfCnpjValidator)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaValidator = pessoaValidator;
            _cpfCnpjValidator = cpfCnpjValidator;
        }
        public Task<IEnumerable<Pessoa>> GetAll()
        {
            return _pessoaRepository.GetAll();
        }

        public Task<Pessoa> GetById(int id)
        {
            return _pessoaRepository.GetById(id);
        }

        public async Task Alterar(Pessoa pessoa)
        {
            _cpfCnpjValidator.Validate(pessoa.CpfCnpj);

            _pessoaValidator.Validate(pessoa, options =>
            {
                options.ThrowOnFailures();
                options.IncludeRuleSets("EmailValidator");
                options.IncludeRuleSets("PessoaValidator");
            });

            await _pessoaRepository.Alterar(pessoa);
        }

        public async Task Incluir(Pessoa pessoa)
        {
            _cpfCnpjValidator.Validate(pessoa.CpfCnpj);

            _pessoaValidator.Validate(pessoa, options =>
            {
                options.ThrowOnFailures();
                options.IncludeRuleSets("EmailValidator");
                options.IncludeRuleSets("PessoaValidator");
            });

            await _pessoaRepository.Incluir(pessoa);
        }

        public Task Excluir(Pessoa pessoa)
        {
            return _pessoaRepository.Excluir(pessoa);
        }
    }
}