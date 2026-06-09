namespace VaccinationCard.Application.Responses
{
    public record GetCartaoVacinacaoResponse(int contaId, string nomeConta, List<CartaoVacinacaoItemResponse> vacinas);
    public record CartaoVacinacaoItemResponse(int vacinacaoId, string nomeVacina, int dose, DateTime dataAplicacao);
}
