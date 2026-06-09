using System.Data;

namespace VaccinationCard.Application.Responses
{
    public record CreateVacinacaoResponse(int vacinacaoId, int contaId, int vacinaId, int dose, DateTime dataAplicacao);
}
