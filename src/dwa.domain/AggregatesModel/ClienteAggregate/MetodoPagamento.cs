using dwa.domain.SeedWork;

namespace dwa.domain.AggregatesModel.ClienteAggregate
{
    public class MetodoPagamento : BaseEntity
    {
        public string Alias { get; set; }
        public string CardId { get; set; } 
        public string Last4 { get; set; }
    }
}
