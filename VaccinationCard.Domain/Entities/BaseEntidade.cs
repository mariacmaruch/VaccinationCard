namespace VaccinationCard.Domain.Entities
{
    public class BaseEntidade
    {
        public int Id { get; set; }
        public DateTime? Criado { get; set; }
        public DateTime? Alterado { get; set; }
        public DateTime? Deletado { get; set; }
        public Guid Identificador { get; set; }
    }
}
