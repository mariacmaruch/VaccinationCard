namespace VaccinationCard.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid identificador, string userName, int contaId);
    }

}
