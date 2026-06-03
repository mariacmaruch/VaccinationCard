using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<Conta> GetAsync(int id);
        Task<Conta> Create(Conta user);
        Task<Conta> Update(Conta user);
        Task<Conta> GetByUserNameAsync (string userName);
        void Remove(int id);
    }
}
