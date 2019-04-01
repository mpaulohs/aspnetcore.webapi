using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dwa.Application.Commands;
using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.infra.data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dwa.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalagoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICatalagoRepository _catalagoRepository;
        private readonly IBlogRepository _blog;

        public CatalagoController(IBlogRepository blog, ICatalagoRepository catalagoRepository, IMediator mediator )
        {
            _blog = blog;
            _catalagoRepository = catalagoRepository;
            _mediator = mediator;
           // _catalogContext = context ?? throw new ArgumentNullException(nameof(context));
          //  _catalogIntegrationEventService = catalogIntegrationEventService ?? throw new ArgumentNullException(nameof(catalogIntegrationEventService));
           // _settings = settings.Value;

            //((DwaContext)context).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        [HttpGet]
        [Route("items/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Blog), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            // var item = await _catalogContext.CatalogoItens.SingleOrDefaultAsync(ci => ci.Id == id);
            var item = await _blog.GetByIdAsync(id);

            //var baseUri = _settings.PicBaseUrl;
            //var azureStorageEnabled = _settings.AzureStorageEnabled;
            //item.FillProductUrl(baseUri, azureStorageEnabled: azureStorageEnabled);

            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }


        //POST api/v1/[controller]/items
        [Route("items")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CriarProduto([FromBody]CriarBlogCommand produto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(produto);
           // var result = await _mediator.Send(produto);
            return CreatedAtAction(nameof(GetItemById), new { id = produto.Id }, null);

            //var item = new CatalogoItem
            //{
            //    CatalogoMarcaId = product.CatalogoMarcaId,
            //    CatalogoTipoId = product.CatalogoTipoId,
            //    Descricao = product.Descricao,
            //    Nome = product.Nome,
            //    ImagemFileName = product.ImagemFileName,
            //    Preco = product.Preco
            //};
            //_catalogContext.CatalogoItens.Add(item);

            //await _catalogContext.SaveChangesAsync();


        }
    }
}