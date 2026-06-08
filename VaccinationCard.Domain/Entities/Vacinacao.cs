namespace VaccinationCard.Domain.Entities
{
    public class Vacinacao : BaseEntidade
    {
        public int ContaId { get; set; }
        public int VacinaId { get; set; }
        public int Dose { get; set; }
        public DateTime DataAplicacao { get; set; }

        public virtual Conta Conta { get; set; }
        public virtual Vacina Vacina { get; set; }
    }
}
