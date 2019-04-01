using dwa.Application.Behaviors;
using dwa.domain.AggregatesModel.CatalogoAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace dwa.Application.Commands
{
    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, Response>
    {
        private readonly ICatalagoRepository _catalagoRepository;

        public CriarProdutoCommandHandler(ICatalagoRepository catalagoRepository)
        {
            _catalagoRepository = catalagoRepository;
        }

        public async Task<Response> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            var cat = new CatalogoItem
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco,
                ImagemFileName = request.ImagemFileName,
                ImagemUri = request.ImagemUri,
                CatalogoTipoId = request.CatalogoTipoId,
                CatalogoMarcaId = request.CatalogoMarcaId
            };

            var result =  await _catalagoRepository.AddAsync(cat);            
            return new Response(result.Id);
        }
    }   
}
