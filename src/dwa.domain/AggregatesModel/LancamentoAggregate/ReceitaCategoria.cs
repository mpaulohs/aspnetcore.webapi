using dwa.domain.SeedWork;
using System.Collections.Generic;

namespace dwa.domain.AggregatesModel.LancamentoAggregate
{
    public class ReceitaCategoria : BaseEntity
    {
        public string Descricao { get; set; }       
        public List<Receita> Receitas { get; set; } = new List<Receita>();
    }
}
