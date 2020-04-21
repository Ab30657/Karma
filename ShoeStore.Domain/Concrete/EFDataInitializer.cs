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
    public class EFDataInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            var products = new List<Product>
            {
                new Product{ ProductId=1, Name="Chicken Meat", CategoryId=2,Description="The infamous red meat of the dragon from GOT series", Price=200.00m, Quantity=200},
                new Product{ ProductId=1, Name="Red Apples", CategoryId=1,Description="The not so special apples", Price=400.00m, Quantity=300}
            };
            var categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruits and Vegetables"},
                new Category{CategoryId=2, CategoryName="Red Meat"}
            };
            categories.ForEach(x => context.Categories.AddOrUpdate(c => c.CategoryId, x));
            products.ForEach(x => context.Products.AddOrUpdate(c => c.ProductId, x));
        }
    }
}
