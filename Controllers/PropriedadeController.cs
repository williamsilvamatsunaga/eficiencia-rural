using eficiencia_rural.DataContexts;
using eficiencia_rural.Models;
using eficiencia_rural.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eficiencia_rural.Controllers
{
    [Route("propriedade")]
    [ApiController]
    public class PropriedadeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropriedadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(
            [FromQuery] string? buscar
            )
        {
            var query = _context.Propriedades.AsQueryable();

            if (buscar is not null)
            {
                query = query.Where(x => x.Nome.Contains(buscar));

                return Ok(query);
            }

            var propriedade = await query.Select(u => new
            {
                u.Nome,
                u.Tamanho,
                u.Endereco
            }).ToListAsync();

            return Ok(propriedade);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] PropriedadeDto novaPropriedade)
        {
            var propriedade = new Propriedade()
            {
                Nome = novaPropriedade.Nome,
                Tamanho = novaPropriedade.Tamanho,
                Endereco = novaPropriedade.Endereco,
            };

            await _context.Propriedades.AddAsync(propriedade);
            await _context.SaveChangesAsync();

            return Created("",propriedade);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var propriedade = await _context.Propriedades.FirstOrDefaultAsync(x => x.Id == id);
            if (propriedade is null)
            {
                return NotFound();
            }

            _context.Propriedades.Remove(propriedade);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
