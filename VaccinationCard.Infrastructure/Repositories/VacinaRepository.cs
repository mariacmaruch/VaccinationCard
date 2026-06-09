using Microsoft.EntityFrameworkCore;
using VaccinationCard.Domain.Entities;
using VaccinationCard.Domain.Interfaces;
using VaccinationCard.Infrastructure.Persistence;

namespace VaccinationCard.Infrastructure.Repositories
{
    public class VacinaRepository : IVacinaRepository
    {
        private readonly AppDbContext _context;

        public VacinaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Vacina> Create(Vacina vacina)
        {
            vacina.Criado ??= DateTime.UtcNow;
            vacina.Alterado ??= DateTime.UtcNow;

            await _context.Vacina.AddAsync(vacina);
            await _context.SaveChangesAsync();

            return vacina;
        }

        public async Task<List<Vacina>> GetAll()
        {
            return await _context.Vacina.AsNoTracking().ToListAsync();
        }

        public async Task<Vacina> GetByIdAsync(int id)
        {
            return await _context.Vacina.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Vacina> GetByNomeAsync(string nome)
        {
            return await _context.Vacina.AsNoTracking().FirstOrDefaultAsync(x => x.Nome.ToLower() == nome.ToLower());
        }
    }
}
