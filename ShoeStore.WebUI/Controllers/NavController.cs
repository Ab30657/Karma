using ShoeStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        IProductRepos repos;
        public NavController(IProductRepos reposParam)
        {
            repos = reposParam;
        }
        // GET: Nav
        public PartialViewResult CategoryMenu()
        {
            IEnumerable<string> categories= repos.Products.Select(x => x.Category).Distinct();
            return PartialView(categories);
        }

        public PartialViewResult ProductFilters()
        {
            return PartialView();
        }

        public PartialViewResult Sorting()
        {
            return PartialView();
        }
    }
}