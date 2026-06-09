using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Domain.Interfaces
{
    public interface IVacinacaoRepository
    {
        Task<Vacinacao> Create(Vacinacao vacinacao);

        Task<Vacinacao?> GetByIdAsync(int id);

        Task<List<Vacinacao>> GetByContaIdAsync(int contaId);

        Task<int> GetUltimaDoseAsync(int contaId, int vacinaId);

        Task DeleteAsync(int id);
    }
}
