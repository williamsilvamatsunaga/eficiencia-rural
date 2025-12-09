using eficiencia_rural.DataContexts;
using eficiencia_rural.Models;
using eficiencia_rural.Models.Dtos;
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

        //

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] InsumoDto novoInsumo)
        {
            var insumo = new Insumo()
            {
                Descricao = novoInsumo.Descricao,
                Categoria = novoInsumo.Categoria,
                UnidadeMedida = novoInsumo.UnidadeMedida,
                Quantidade = novoInsumo.Quantidade
                
            };

            await _context.Insumos.AddAsync(insumo);
            await _context.SaveChangesAsync();

            return Created("", insumo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] InsumoDto novoInsumo)
        {

            var insumo = await _context.Insumos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (insumo is null)
            {
                return NotFound();
            }

            insumo.Descricao = novoInsumo.Descricao;
            insumo.Categoria = novoInsumo.Categoria;
            insumo.UnidadeMedida = novoInsumo.UnidadeMedida;
            insumo.Quantidade = novoInsumo.Quantidade;
            insumo.ValorUnitario = novoInsumo.ValorUnitario;

            _context.Insumos.Update(insumo);
            await _context.SaveChangesAsync();

            return Ok(insumo);
        }

        //

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
