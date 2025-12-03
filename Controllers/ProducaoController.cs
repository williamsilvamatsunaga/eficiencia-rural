using eficiencia_rural.DataContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eficiencia_rural.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducaoController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ProducaoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(
            [FromQuery] string? buscar
            )
        {
            var query = _context.Producoes.AsQueryable();

            if (buscar is not null)
            {
                query = query.Where(x => x.Id.ToString().Contains(buscar));

                return Ok(query);
            }

            var producao = await query.Select(p => new
            {
                p.ValorUnitario,
                p.QuantidadeVacas,
                p.DataHoraInicio,
                p.QuantidadeLitros



            }).ToListAsync();

            return Ok(producao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var producao = await _context.Producoes.FirstOrDefaultAsync(x => x.Id == id);
            if (producao is null)
            {
                return NotFound();
            }

            _context.Producoes.Remove(producao);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
