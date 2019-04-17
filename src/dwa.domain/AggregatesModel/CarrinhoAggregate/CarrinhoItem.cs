using dwa.domain.SeedWork;

namespace dwa.domain.AggregatesModel.CarrinhoAggregate
{
    public class CarrinhoItem : BaseEntity
    {
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public int CatalogoItemId { get; set; }
    }
}
