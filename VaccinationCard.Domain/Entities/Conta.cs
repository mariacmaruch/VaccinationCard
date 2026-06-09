namespace VaccinationCard.Domain.Entities
{
    public class Conta : BaseEntidade
    {
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Vacinacao> Vacinacoes { get; set; } = new List<Vacinacao>();
    }
}
