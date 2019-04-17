using Ardalis.GuardClauses;
using System.Collections.Generic;
using dwa.domain.SeedWork;

namespace dwa.domain.AggregatesModel.ClienteAggregate
{
    public class Cliente : BaseEntity
    {
        public string IdentityGuid { get; private set; }

        private List<MetodoPagamento> _metodosPagamentos = new List<MetodoPagamento>();

        public IEnumerable<MetodoPagamento> MetodoPagamentos => _metodosPagamentos.AsReadOnly();

        private Cliente()
        {
            // required by EF
        }

        public Cliente(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }
    }
}
