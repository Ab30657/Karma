using ShoeStore.Domain.Abstract;
using ShoeStore.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.WebUI.Controllers
{
    public class StoreController : Controller
    {
        private IProductRepos repos;
        public StoreController(IProductRepos reposPara)
        {
            repos = reposPara;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {
            return View();
        }

    }
}