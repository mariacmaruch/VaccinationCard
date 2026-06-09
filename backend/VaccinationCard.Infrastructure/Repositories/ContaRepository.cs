using Microsoft.EntityFrameworkCore;
using VaccinationCard.Domain.Entities;
using VaccinationCard.Domain.Interfaces;
using VaccinationCard.Infrastructure.Persistence;

namespace VaccinationCard.Infrastructure.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly AppDbContext _context;

        public ContaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Conta> GetByIdAsync(int id)
        {
            return await _context.Conta.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Conta> Create(Conta user)
        {
            user.Criado ??= DateTime.UtcNow;
            user.Alterado ??= DateTime.UtcNow;

            await _context.Conta.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<Conta> Update(Conta conta)
        {
            var existing = await _context.Conta.FirstOrDefaultAsync(x => x.Id == conta.Id);

            if (existing == null)
                return null;

            conta.Alterado = DateTime.UtcNow;

            _context.Entry(existing).CurrentValues.SetValues(conta);

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<Conta> GetByUserNameAsync(string userName)
        {
            return await _context.Conta.AsNoTracking().FirstOrDefaultAsync(x => x.Nome == userName);
        }

        public async Task Remove(int id)
        {
            var conta = await _context.Conta.FirstOrDefaultAsync(x => x.Id == id);

            if (conta == null)
                return;

            _context.Conta.Remove(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<Conta> GetByCpfCnpjAsync(string cnfCnpj)
        {
            return await _context.Conta.AsNoTracking().FirstOrDefaultAsync(x => x.CpfCnpj == cnfCnpj);
        }
    }
}