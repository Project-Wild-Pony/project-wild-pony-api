using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Project.Wild.Pony.Domain.Catalog;
using Project.Wild.Pony.Data; 

namespace Project.Wild.Pony.Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet("db")]              // /catalog/db
        public IActionResult GetItemsFromDb() => Ok(_db.Items);

        [HttpGet("db/{id:int}")]     // /catalog/db/{id}
        public IActionResult GetItemFromDb(int id) 
        {
            var item = _db.Items.Find(id);
             if (item == null) return NotFound();
         return Ok(item);
        }
        
        [HttpGet]
        public IActionResult GetItems()
        {
            var items = new List<Item>()
            {
                new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };

            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;

            return Ok(item);
        }
        [HttpPost]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
        }
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.Ratings.Add(rating);

            return Ok(item);
        }
        [HttpPut("id:int")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}