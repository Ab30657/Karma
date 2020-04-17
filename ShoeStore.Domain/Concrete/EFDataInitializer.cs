using ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Domain.Concrete
{
    public class EFDataInitializer: DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var products = new List<Product>
            {
                new Product{ ProductId=1, Name="Nike Max", Category="Nike", Price=200.00m, Quantity=200},
                new Product{ ProductId=1, Name="Nike Air", Category="Nike", Price=400.00m, Quantity=300}
            };

            products.ForEach(x => context.Products.AddOrUpdate(c => c.ProductId, x));
        }
    }
}
