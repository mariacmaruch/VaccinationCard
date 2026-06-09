using Microsoft.EntityFrameworkCore;
using VaccinationCard.Domain.Entities;
using VaccinationCard.Domain.Interfaces;
using VaccinationCard.Infrastructure.Persistence;

namespace VaccinationCard.Infrastructure.Repositories
{
    public class VacinacaoRepository : IVacinacaoRepository
    {
        private readonly AppDbContext _context;

        public VacinacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vacinacao> Create(Vacinacao vacinacao)
        {
            vacinacao.Criado ??= DateTime.UtcNow;
            vacinacao.Alterado ??= DateTime.UtcNow;

            await _context.Vacinacao.AddAsync(vacinacao);
            await _context.SaveChangesAsync();

            return vacinacao;
        }

        public async Task<Vacinacao?> GetByIdAsync(int id)
        {
            return await _context.Vacinacao
                .Include(x => x.Vacina)
                .Include(x => x.Conta)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Vacinacao>> GetByContaIdAsync(int contaId)
        {
            return await _context.Vacinacao
                .Include(x => x.Vacina)
                .Where(x => x.ContaId == contaId)
                .OrderBy(x => x.DataAplicacao)
                .ToListAsync();
        }

        public async Task<int> GetUltimaDoseAsync(int contaId, int vacinaId)
        {
            var ultimaDose = await _context.Vacinacao
                .Where(x => x.ContaId == contaId && x.VacinaId == vacinaId)
                .OrderByDescending(x => x.Dose)
                .Select(x => x.Dose)
                .FirstOrDefaultAsync();

            return ultimaDose;
        }

        public async Task DeleteAsync(int id)
        {
            var vacinacao = await _context.Vacinacao.FindAsync(id);

            if (vacinacao == null)
                return;

            _context.Vacinacao.Remove(vacinacao);
            await _context.SaveChangesAsync();
        }
    }
}
