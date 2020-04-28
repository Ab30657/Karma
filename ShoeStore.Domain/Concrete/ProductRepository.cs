using ShoeStore.Domain.Abstract;
using ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;

namespace ShoeStore.Domain.Concrete
{
    public class ProductRepository : IProductRepos
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
        public IEnumerable<Category> Categories
        {
            get { return context.Categories.Include(x=>x.SubCategories); }
        }

        public Product GetProduct(int productId)
        {
            Product product = context.Products.Find(productId);
            return product;
        }

        public string Add(Product item)
        {
            context.Products.Add(item);
            context.SaveChanges();
            return item.Name;
        }

        public string Remove(int id)
        {
            Product product= context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product.Name;
        }

        public string Update(Product product)
        {
            Product dbEntry = context.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>());
            var mapper = config.CreateMapper();
            dbEntry = mapper.Map<Product>(product);
            return product.Name;
        }
    }
}
