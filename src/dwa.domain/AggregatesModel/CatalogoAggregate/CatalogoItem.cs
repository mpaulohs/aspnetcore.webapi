using dwa.domain.Exceptions;
using dwa.domain.SeedWork;
using System;

namespace dwa.domain.AggregatesModel.CatalogoAggregate
{
    public class CatalogoItem : BaseEntity
    {    
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemFileName { get; set; }
        public string ImagemUri { get; set; }
        public int CatalogoTipoId { get; set; }
        public CatalogoTipo CatalogoTipo { get; set; }
        public int CatalogoMarcaId { get; set; }
        public CatalogoMarca CatalogoMarca { get; set; }
        // Quantidade em estoque
        public int EstoqueDisponivel { get; set; }
        // estoque disponível em que devemos reordenar
        public int RestockThreshold { get; set; }

        // Número máximo de unidades que podem estar em estoque a qualquer momento (devido a restrições físicas / logísticas nos armazéns)
        public int MaxStockThreshold { get; set; }

        /// <summary>
        /// true se o item estiver em reordenar
        /// </summary>
        public bool OnReorder { get; set; }

        public CatalogoItem() { }


        /// <summary>
        /// Decrements the quantity of a particular item in inventory and ensures the restockThreshold hasn't
        /// been breached. If so, a RestockRequest is generated in CheckThreshold. 
        /// 
        /// If there is sufficient stock of an item, then the integer returned at the end of this call should be the same as quantityDesired. 
        /// In the event that there is not sufficient stock available, the method will remove whatever stock is available and return that quantity to the client.
        /// In this case, it is the responsibility of the client to determine if the amount that is returned is the same as quantityDesired.
        /// It is invalid to pass in a negative number. 
        /// </summary>
        /// <param name="quantityDesired"></param>
        /// <returns>int: Returns the number actually removed from stock. </returns>
        /// 
        public int RemoveStock(int quantityDesired)
        {
            if (EstoqueDisponivel == 0)
            {
                throw new CatalogoDomainException($"O estoque vazio, item do produto {Nome} está esgotado");
            }

            if (quantityDesired <= 0)
            {
                throw new CatalogoDomainException($"As unidades de item desejadas devem ser maiores que zero");
            }

            int removed = Math.Min(quantityDesired, this.EstoqueDisponivel);

            this.EstoqueDisponivel -= removed;

            return removed;
        }

        /// <summary>
        /// Increments the quantity of a particular item in inventory.
        /// <param name="quantity"></param>
        /// <returns>int: Returns the quantity that has been added to stock</returns>
        /// </summary>
        public int AddStock(int quantity)
        {
            int original = this.EstoqueDisponivel;

            // The quantity that the client is trying to add to stock is greater than what can be physically accommodated in the Warehouse
            if ((this.EstoqueDisponivel + quantity) > this.MaxStockThreshold)
            {
                // For now, this method only adds new units up maximum stock threshold. In an expanded version of this application, we
                //could include tracking for the remaining units and store information about overstock elsewhere. 
                this.EstoqueDisponivel += (this.MaxStockThreshold - this.EstoqueDisponivel);
            }
            else
            {
                this.EstoqueDisponivel += quantity;
            }

            this.OnReorder = false;

            return this.EstoqueDisponivel - original;
        }
    }
}