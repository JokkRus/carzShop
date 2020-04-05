using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
    }

    public class CarDbInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext db)
        {
            db.Cars.Add(new Car { Mark = "Skoda", Model = "Rapid", Color = "Blue", Price = 1_200_000 });
            db.Cars.Add(new Car { Mark = "KIA", Model = "Rio", Color = "White", Price = 1_000_000 });
            db.Cars.Add(new Car { Mark = "Hyundai", Model = "Solaris", Color = "Black", Price = 1_050_000 });
            db.Cars.Add(new Car { Mark = "Lada", Model = "Vesta", Color = "Gray", Price = 900_000 });
            base.Seed(db);
        }
    }
}