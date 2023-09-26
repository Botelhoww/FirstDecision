using FirstDecision.DataLayer.Context;
using FirstDecision.DataLayer.Repositories.Interfaces;
using FirstDecision.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace FirstDecision.DataLayer.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly FirstDecisionContext _context;

        public PessoaRepository(FirstDecisionContext context)
        {
            _context = context;
        }

        public async Task Alterar(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Pessoa pessoa)
        {
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await _context.Pessoa.ToListAsync();
        }

        public async Task<Pessoa> GetById(int id)
        {
            return await _context.Pessoa.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task Incluir(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            await _context.SaveChangesAsync();
        }
    }
}
