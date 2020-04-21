using ShoeStore.Domain.Abstract;
using ShoeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        IProductRepos repos;
        public AdminController(IProductRepos repoParam)
        {
            repos = repoParam;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> products = repos.Products;
            return View(products);
        }
    }
}