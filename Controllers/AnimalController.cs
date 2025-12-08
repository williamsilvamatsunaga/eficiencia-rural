using eficiencia_rural.DataContexts;
using eficiencia_rural.Models;
using eficiencia_rural.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eficiencia_rural.Controllers
{
    [Route("/animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos(
            [FromQuery] string? buscar
            )
        {
            var query = _context.Animais.AsQueryable();

            if(buscar is not null)
            {
                query = query.Where(x => x.Identificacao.Contains(buscar));
                return Ok(query);
            }

            var animais = await query
                .Include(c => c.Categoria)
                .Include(p => p.Propriedade)
                .Select(c => new
                {
                    c.Id,
                    c.Identificacao,
                    c.DataNascimento,
                    c.Peso,
                    Categoria = new {c.Categoria.Nome},
                    Propriedade = new { c.Propriedade.Nome, c.Propriedade.Endereco }
                }).ToListAsync();
                
            return Ok(animais);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AnimalDto novoAnimal)
        {
            var categoria = await _context.Categorias
            .FirstOrDefaultAsync(x => x.Id == novoAnimal.fk_id_categoria);

            if(categoria is null)
            {
                return NotFound("Categoria informada não encontrada!");
            }

            var animal = new Animal()
            {
              Identificacao = novoAnimal.Identificacao,
              DataNascimento = novoAnimal.DataNascimento,
              Peso = novoAnimal.Peso,
              fk_id_categoria = novoAnimal.fk_id_categoria,
              fk_id_propriedade = novoAnimal.fk_id_propriedade,
            };

            await _context.Animais.AddAsync(animal);
            await _context.SaveChangesAsync();

            return Created("", animal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AnimalDto atualizarAnimal)
        {
            var animal = await _context.Animais
                .Include(c => c.Categoria)
                .Include(p => p.Propriedade)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(animal is null)
            {
                return NotFound();
            }

            animal.Peso = atualizarAnimal.Peso;
            animal.fk_id_categoria = atualizarAnimal.fk_id_categoria;
            animal.fk_id_propriedade = atualizarAnimal.fk_id_propriedade;

            _context.Animais.Update(animal);
            await _context.SaveChangesAsync();

            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var animal = await _context.Animais.FirstOrDefaultAsync(x => x.Id == id);
            if (animal is null)
            {
                return NotFound();
            }

            bool possuiProducao = await _context.Producoes
                .AnyAsync(x => x.fk_id_animal == id);

            if (possuiProducao)
            {
                return BadRequest("Não foi possível excluir animal, pois existem produções vinculadas!");
            }

            _context.Animais.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
