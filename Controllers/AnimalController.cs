using eficiencia_rural.DataContexts;
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
                query = query.Where(x => x.Indentificacao.Contains(buscar));
                return Ok(query);
            }

            var animais = await query.Select(a => new
            {
                a.Indentificacao

            }).ToListAsync();

            return Ok(animais);
        }
    }
}
