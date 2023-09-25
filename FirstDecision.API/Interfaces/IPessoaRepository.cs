using FirstDecision.API.Models;

namespace FirstDecision.API.Interfaces
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> BuscarTodos();
        Task<Pessoa> BuscarPorId(int id);
        public void Incluir(Pessoa pessoa);
        public void Atualizar(Pessoa pessoa);
        public void Excluir(int id);
    }
}
