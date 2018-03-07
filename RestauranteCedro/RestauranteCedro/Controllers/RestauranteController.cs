using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestauranteCedro.Entities;

namespace RestauranteCedro.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {
        private readonly RestauranteCedroContext _context;
        
        public RestauranteController(RestauranteCedroContext context)
        {
            _context = context;
        }
        
        [HttpGet("All")]
        public IEnumerable<Restaurante> GetAll()
        {
            return _context.Restaurantes.ToList();
        }

        [HttpGet("{id}", Name = "GetRestaurante")]
        public IActionResult GetById(int id)
        {
            var item = _context.Restaurantes.FirstOrDefault(r => r.id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Restaurante restaurante)
        {
            if (restaurante == null)
            {
                return BadRequest();
            }

            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();

            return CreatedAtRoute("GetRestaurante", new
            {
                id = restaurante.id,
                nome = restaurante.nome
            }, restaurante);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Restaurante restaurante)
        {
            if (restaurante == null || restaurante.id != id)
            {
                return BadRequest();
            }

            var item = _context.Restaurantes.FirstOrDefault(r => r.id == id);
            if (item == null)
            {
                return NotFound();
            }

            item.nome = restaurante.nome;

            _context.Restaurantes.Update(item);
            _context.SaveChanges();
            return new NoContentResult();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Restaurantes.FirstOrDefault(r => r.id == id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Restaurantes.Remove(item);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}