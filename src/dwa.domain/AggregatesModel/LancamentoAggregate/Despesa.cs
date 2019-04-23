using dwa.domain.SeedWork;
using System;

namespace dwa.domain.AggregatesModel.LancamentoAggregate
{
    public class Despesa : BaseEntity
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int DespesaCategoriaId { get; set; }
        public DespesaCategoria DespesaCategoria { get; set; }
    }
}
