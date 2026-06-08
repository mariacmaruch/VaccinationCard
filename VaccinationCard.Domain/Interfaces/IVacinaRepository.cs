using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Domain.Interfaces
{
    public interface IVacinaRepository
    {
        Task<Vacina> Create(Vacina vacina);
        Task<Vacina> GetByIdAsync(int id);
        Task<Vacina> GetByNomeAsync(string nome);
    }
}
