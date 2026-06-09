namespace VaccinationCard.Application.Responses
{
    public record GetAllVacinasResponse(List<VacinaResponse> vacinas);

    public record VacinaResponse(int vacinaId, string nomeVacina);
}
