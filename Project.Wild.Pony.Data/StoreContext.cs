using Microsoft.EntityFrameworkCore;
using Project.Wild.Pony.Domain.Catalog; 

namespace Project.Wild.Pony.Data
{
    public class StoreContext : DbContext
    {
      
        public StoreContext() { }
        
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
       
        public DbSet<Item> Items { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)  
        {
            base.OnModelCreating(builder);                             
            DbInitializer.Initialize(builder);                         
        }
    }
}
