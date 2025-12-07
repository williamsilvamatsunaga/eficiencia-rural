using eficiencia_rural.DataContexts;
using eficiencia_rural.Models;
using eficiencia_rural.Models.Dtos;
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


            var producao = await query
                .Include(a => a.Animal)
                .Select(a => new
                {
                a.Id,
                a.ValorUnitario,
                a.DataHoraInicio,
                a.QuantidadeLitros,
                Animal = new {a.Animal.Identificacao}
            }).ToListAsync();

            return Ok(producao);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ProducaoDto novaProducao)
        {
            var animal = await _context.Animais
                 .FirstOrDefaultAsync(x => x.Id == novaProducao.fk_id_animal);

            if (animal is null)
            {
                return NotFound("Animal informado não encontrado!");
            }

            var producao = new Producao()
            {
                QuantidadeLitros = novaProducao.QuantidadeLitros,
                DataHoraInicio = novaProducao.DataHoraInicio,
                ValorUnitario = novaProducao.ValorUnitario,
                fk_id_animal = novaProducao.fk_id_animal,
            };

            await _context.Producoes.AddAsync(producao);
            await _context.SaveChangesAsync();

            return Created("", producao);
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
