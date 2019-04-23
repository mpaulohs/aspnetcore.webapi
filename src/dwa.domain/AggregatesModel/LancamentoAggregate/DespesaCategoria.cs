using dwa.domain.SeedWork;
using System.Collections.Generic;

namespace dwa.domain.AggregatesModel.LancamentoAggregate
{
    public class DespesaCategoria : BaseEntity
    {
        public string Descricao { get; set; }
        public List<Despesa> Despesas { get; set; } = new List<Despesa>();
    }

}
