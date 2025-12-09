using eficiencia_rural.DataContexts;
using eficiencia_rural.Models;
using eficiencia_rural.Models.Dtos;
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

            var piquetes = await query
                .Include(p => p.Propriedade)
                .Select(c => new
                {
                    c.Nome,
                    c.Tamanho,
                    c.TipoPastagem,
                    Propriedade = new { c.Propriedade.Nome }
                }).ToListAsync();

            return Ok(piquetes);
        }

        //
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] PiqueteDto novoPiquete)
        {
            var piquete = new Piquete()
            {

                Nome = novoPiquete.Nome,
                Tamanho = novoPiquete.Tamanho,
                TipoPastagem = novoPiquete.TipoPastagem,
                fk_id_propriedade = novoPiquete.fk_id_propriedade
            };

            await _context.Piquetes.AddAsync(piquete);
            await _context.SaveChangesAsync();

            return Created("", piquete);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] PiqueteDto atualizarPiquete)
        {
            var piquete = await _context.Piquetes
                .Include(c => c.Propriedade)       
                .FirstOrDefaultAsync(x => x.Id == id);

            if (piquete is null)
            {
                return NotFound();
            }

            piquete.Nome = atualizarPiquete.Nome;
            piquete.Tamanho = atualizarPiquete.Tamanho;
            piquete.TipoPastagem = atualizarPiquete.TipoPastagem;

            _context.Piquetes.Update(piquete);
            await _context.SaveChangesAsync();

            return Ok(piquete);
        }

        //

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
