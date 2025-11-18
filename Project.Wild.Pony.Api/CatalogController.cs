using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Project.Wild.Pony.Domain.Catalog;
using Project.Wild.Pony.Data;
using Microsoft.EntityFrameworkCore;  // Include(...)
using System.Linq;                    // FirstOrDefault(...)


namespace Project.Wild.Pony.Api.Controllers
{
    [ApiController]
    [Route("catalog")]
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
                new Item("Shirt",  "Ohio State shirt.",  "Nike", 29.99m),
                new Item("Shorts", "Ohio State shorts.", "Nike", 44.99m)
            };

            return Ok(_db.Items);
        }

        // GET /catalog/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_db.Items.Find(id));
        }

        // POST /catalog
        [HttpPost]
        public IActionResult Post(Item item)
        {
            // Simulate creation; database wiring comes later.
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        

        // PUT /catalog/{id}
       // PUT /catalog/{id}
[HttpPut("{id:int}")]
public IActionResult Put(int id, [FromBody] Item item)
{
    if (id != item.Id)
    {
        return BadRequest("ID in URL does not match ID in request body");
    }
    
    var existingItem = _db.Items.Find(id);
    if (existingItem == null)
    {
        return NotFound();
    }
    
    _db.Entry(existingItem).CurrentValues.SetValues(item);
    _db.SaveChanges();
    
    return NoContent();
}
    
    
        // POST /catalog/{id}/ratings
[HttpPost("{id:int}/ratings")]
public IActionResult PostRating(int id, [FromBody] Rating rating)
{
    // Find the item by id
    var item = _db.Items.Find(id);
    
    // If item doesn't exist, return 404
    if (item == null)
    {
        return NotFound();
    }
    
    // Add the rating to the item using our domain logic
    item.AddRating(rating);
    
    // Save changes to the database
    _db.SaveChanges();
    
    // Return the updated item with its new rating
    return Ok(item);
}
        



        // DELETE /catalog/{id}
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // Simulate deletion; return 204 No Content.
            return NoContent();
        }
       

    }
    

}
