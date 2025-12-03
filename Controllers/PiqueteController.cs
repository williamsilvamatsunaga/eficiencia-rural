using eficiencia_rural.DataContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eficiencia_rural.Controllers
{
    [Route("piquete")]
    [ApiController]
    public class PiqueteController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public PiqueteController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(
            [FromQuery] string? buscar
            )
        {
            var query = _context.Piquetes.AsQueryable();

            if (buscar is not null)
            {
                query = query.Where(x => x.Nome.Contains(buscar));

                return Ok(query);
            }

            var piquetes = await query.Select(p => new
            {
                p.Id,
                p.Nome,
                p.Tamanho,
                p.TipoPastagem,

            }).ToListAsync();

            return Ok(piquetes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var piquete = await _context.Piquetes.FirstOrDefaultAsync(x => x.Id == id);
            if (piquete is null)
            {
                return NotFound();
            }

            _context.Piquetes.Remove(piquete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
