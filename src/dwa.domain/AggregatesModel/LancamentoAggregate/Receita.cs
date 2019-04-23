using dwa.domain.SeedWork;
using System;

namespace dwa.domain.AggregatesModel.LancamentoAggregate
{
    public class Receita : BaseEntity
    {
        public decimal Valor{ get; set; }
        public DateTime Data { get; set; }
        public int ReceitaCategoriaId { get; set; }
        public ReceitaCategoria ReceitaCategoria { get; set; }
    }
}
