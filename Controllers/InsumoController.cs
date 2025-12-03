using eficiencia_rural.DataContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eficiencia_rural.Controllers
{
    [Route("insumo")]
    [ApiController]
    public class InsumoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InsumoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(
            [FromQuery] string? buscar
            )
        {
            var query = _context.Insumos.AsQueryable();

            if (buscar is not null)
            {
                query = query.Where(x => x.Id.ToString().Contains(buscar));

                return Ok(query);
            }

            var categorias = await query.Select(c => new
            {
                c.Descricao,
                c.UnidadeMedida,
                c.Categoria,
                c.Quantidade,
                c.ValorUnitario
            }).ToListAsync();

            return Ok(categorias);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var insumo = await _context.Insumos.FirstOrDefaultAsync(x => x.Id == id);
            if (insumo is null)
            {
                return NotFound();
            }

            _context.Insumos.Remove(insumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
