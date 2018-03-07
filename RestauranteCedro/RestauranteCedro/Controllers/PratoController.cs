using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestauranteCedro.Entities;

namespace RestauranteCedro.Controllers
{
    [Route("api/[controller]")]
    public class PratoController : Controller
    {
        private readonly RestauranteCedroContext _context;

        public PratoController(RestauranteCedroContext context)
        {
            _context = context;
        }

        [HttpGet("All")]
        public IEnumerable<Prato> GetAll()
        {
            return _context.Pratos.ToList();
        }

        [HttpGet("{id}", Name = "GetPrato")]
        public IActionResult GetById(int id)
        {
            var item = _context.Pratos.FirstOrDefault(p => p.id == id);
            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Prato prato)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(r => r.id == prato.idRestaurante);
            if (prato == null || restaurante == null)
            {
                return BadRequest();
            }

            _context.Pratos.Add(prato);
            _context.SaveChanges();

            return CreatedAtRoute("GetPrato", new
            {
                id = prato.id,
                descricao = prato.descricao,
                preco = prato.preco,
                idRestaurante = prato.idRestaurante
            }, prato);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Prato prato)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(r => r.id == prato.idRestaurante);
            if (prato == null || prato.id != id || restaurante == null)
            {
                return BadRequest();
            }

            var item = _context.Pratos.FirstOrDefault(p => p.id== id);
            if (item == null)
            {
                return NotFound();
            }

            item.descricao = prato.descricao;
            item.preco = prato.preco;
            item.idRestaurante = prato.idRestaurante;

            _context.Pratos.Update(item);
            _context.SaveChanges();
            return new NoContentResult();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Pratos.FirstOrDefault(p => p.id== id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Pratos.Remove(item);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}