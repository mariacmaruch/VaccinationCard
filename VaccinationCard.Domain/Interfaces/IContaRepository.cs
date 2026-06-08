using VaccinationCard.Domain.Entities;

namespace VaccinationCard.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<Conta> GetByIdAsync(int id);
        Task<Conta> Create(Conta user);
        Task<Conta> Update(Conta user);
        Task<Conta> GetByUserNameAsync (string userName);
        Task<Conta> GetByCpfCnpjAsync(string cnfCnpj);
        Task Remove(int id);
    }
}
