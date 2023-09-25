using FirstDecision.Model.Entities;

namespace FirstDecision.DataLayer.Repositories.Interfaces
{
    public interface IPessoaRepository
    {
        Task Incluir(Pessoa pessoa);
        Task Alterar(Pessoa pessoa);
        Task Excluir(Pessoa pessoa);

        Task<Pessoa> GetById(int id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}