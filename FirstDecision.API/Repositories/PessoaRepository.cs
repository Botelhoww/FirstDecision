using FirstDecision.API.Interfaces;
using FirstDecision.API.Models;

namespace FirstDecision.API.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly FirstDecisionContext _context;

        public PessoaRepository(FirstDecisionContext context)
        {
            _context = context;
        }

        public void Atualizar(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<Pessoa> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pessoa>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
    }
}
