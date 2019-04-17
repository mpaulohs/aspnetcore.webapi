using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using dwa.domain.SeedWork;

namespace dwa.domain.AggregatesModel.OrdemAggregate
{
    public class Ordem : BaseEntity
    {
        private Ordem()
        {
            // required by EF
        }

        public Ordem(string clienteId, Endereco enviarParaEndereco, List<OrdemItem> items)
        {
            Guard.Against.NullOrEmpty(clienteId, nameof(clienteId));
            Guard.Against.Null(enviarParaEndereco, nameof(enviarParaEndereco));
            Guard.Against.Null(items, nameof(items));

            ClienteId = clienteId;
            EnderecoParaEntrega = enviarParaEndereco;
            _orderItems = items;
        }
        public string ClienteId { get; private set; }

        public DateTimeOffset DataPedido { get; private set; } = DateTimeOffset.Now;
        public Endereco EnderecoParaEntrega { get; private set; }

        // DDD Patterns comment
        // Using a private collection field, better for DDD Aggregate's encapsulation
        // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
        // but only through the method Order.AddOrderItem() which includes behavior.
        private readonly List<OrdemItem> _orderItems = new List<OrdemItem>();

        public IReadOnlyCollection<OrdemItem> OrderItems => _orderItems.AsReadOnly();
        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _orderItems)
            {
                total += item.PrecoUnitario * item.Unidades;
            }
            return total;
        }
    }
}
