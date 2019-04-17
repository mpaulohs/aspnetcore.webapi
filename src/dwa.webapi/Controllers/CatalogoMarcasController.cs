using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.infra.data;

namespace dwa.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoMarcasController : ControllerBase
    {
        private readonly DwaContext _context;

        public CatalogoMarcasController(DwaContext context)
        {
            _context = context;
        }

        // GET: api/CatalogoMarcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoMarca>>> GetCatalogoMarcas()
        {
            return await _context.CatalogoMarcas.ToListAsync();
        }

        // GET: api/CatalogoMarcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoMarca>> GetCatalogoMarca(int id)
        {
            var catalogoMarca = await _context.CatalogoMarcas.FindAsync(id);

            if (catalogoMarca == null)
            {
                return NotFound();
            }

            return catalogoMarca;
        }

        // PUT: api/CatalogoMarcas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogoMarca(int id, CatalogoMarca catalogoMarca)
        {
            if (id != catalogoMarca.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogoMarca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoMarcaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CatalogoMarcas
        [HttpPost]
        public async Task<ActionResult<CatalogoMarca>> PostCatalogoMarca(CatalogoMarca catalogoMarca)
        {
            _context.CatalogoMarcas.Add(catalogoMarca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogoMarca", new { id = catalogoMarca.Id }, catalogoMarca);
        }

        // DELETE: api/CatalogoMarcas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatalogoMarca>> DeleteCatalogoMarca(int id)
        {
            var catalogoMarca = await _context.CatalogoMarcas.FindAsync(id);
            if (catalogoMarca == null)
            {
                return NotFound();
            }

            _context.CatalogoMarcas.Remove(catalogoMarca);
            await _context.SaveChangesAsync();

            return catalogoMarca;
        }

        private bool CatalogoMarcaExists(int id)
        {
            return _context.CatalogoMarcas.Any(e => e.Id == id);
        }
    }
}
