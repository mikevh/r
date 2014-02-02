using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace r.Controllers
{
    public class RController : Controller
    {
        //
        // GET: /R/
        public ActionResult Index()
        {
            return RedirectPermanent("http://twitter.com");

            //return View();
        }
	}
}