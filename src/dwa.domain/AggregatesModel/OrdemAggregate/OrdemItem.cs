using dwa.domain.SeedWork;

namespace dwa.domain.AggregatesModel.OrdemAggregate
{

    public class OrdemItem : BaseEntity
    {
        public CatalogoItemOrdem CatalogoItemOrdem { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public int Unidades { get; private set; }

        private OrdemItem()
        {
            // required by EF
        }

        public OrdemItem(CatalogoItemOrdem itemOrdered, decimal precoUnitario, int unidades)
        {
            CatalogoItemOrdem = itemOrdered;
            PrecoUnitario = precoUnitario;
            Unidades = unidades;
        }
    }
}
