using FirstDecision.Business.Services.Interfaces;
using FirstDecision.DataLayer.Repositories.Interfaces;
using FirstDecision.Model.Entities;

namespace FirstDecision.Business.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Task Alterar(Pessoa pessoa)
        {
            return _pessoaRepository.Alterar(pessoa);
        }

        public Task Excluir(Pessoa pessoa)
        {
            return _pessoaRepository.Excluir(pessoa);
        }

        public Task<IEnumerable<Pessoa>> GetAll()
        {
            return _pessoaRepository.GetAll();
        }

        public Task<Pessoa> GetById(int id)
        {
            return _pessoaRepository.GetById(id);
        }

        public async Task Incluir(Pessoa pessoa)
        {
            //usar fluent validation pro nome e email not null
            //usar fluent para validar email

            await _pessoaRepository.Incluir(pessoa);
        }
    }
}