using ShoeStore.Domain.Abstract;
using ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ShoeStore.WebUI.Controllers
{
    public class AdminController : ApiController
    {
        // GET: Admin
        IProductRepos repos;
        public AdminController(IProductRepos repoParam)
        {
            repos = repoParam;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repos.Products;
        }

        public Product GetProduct(int id)
        {
            return repos.GetProduct(id);
        }

        public string PutProduct(Product item)
        {
            return repos.Update(item);
        }

        public string DeleteProduct(int id)
        {
            return repos.Remove(id);
        }

        public string PostProduct(Product product)
        {
            return repos.Add(product);
        }

    }
}