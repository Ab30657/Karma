using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.WebUI.Controllers
{
    public class BagController : Controller
    {
        // GET: Bag
        public ActionResult Index()
        {
            return View();
        }
    }
}