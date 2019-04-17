using Ardalis.GuardClauses;

namespace dwa.domain.AggregatesModel.OrdemAggregate
{
    /// <summary>
    /// Represents a snapshot of the item that was ordered. If catalog item details change, details of
    /// the item that was part of a completed order should not change.
    /// </summary>
    public class CatalogoItemOrdem // ValueObject
    {
        public CatalogoItemOrdem(int catalogoItemId, string produtoNome, string pictureUri)
        {
            Guard.Against.OutOfRange(catalogoItemId, nameof(catalogoItemId), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(produtoNome, nameof(produtoNome));
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));

            CatalogoItemId = catalogoItemId;
            ProdutoNome = produtoNome;
            PictureUri = pictureUri;
        }

        private CatalogoItemOrdem()
        {
            // required by EF
        }

        public int CatalogoItemId { get; private set; }
        public string ProdutoNome { get; private set; }
        public string PictureUri { get; private set; }
    }
}
