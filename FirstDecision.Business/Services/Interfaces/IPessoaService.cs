using FirstDecision.Model.Entities;
namespace FirstDecision.Business.Services.Interfaces
{
    public interface IPessoaService
    {
        Task Incluir(Pessoa pessoa);
        Task Alterar(Pessoa pessoa);
        Task Excluir(Pessoa pessoa);

        Task<Pessoa> GetById(int id);
        Task<IEnumerable<Pessoa>> GetAll();
    }
}
