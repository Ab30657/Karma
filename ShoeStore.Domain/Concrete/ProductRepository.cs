using ShoeStore.Domain.Abstract;
using ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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
    }
}
