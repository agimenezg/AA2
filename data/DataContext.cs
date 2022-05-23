using Microsoft.EntityFrameworkCore;

using ProductItem;
using CarritoItem;

namespace Product.Data
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<ProductItems>? ProductItem { get; set; }
        public DbSet<CarritoItems>? CarritoItem { get; set; }
    }
}
