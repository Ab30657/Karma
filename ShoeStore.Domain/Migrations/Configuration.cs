namespace ShoeStore.Domain.Migrations
{
    using ShoeStore.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoeStore.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShoeStore.Domain.Concrete.EFDbContext context)
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
