using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using r.Models;

namespace r.Controllers
{
    public class RController : Controller
    {
        private LinkContext db = new LinkContext();

        public ActionResult Index(string code)
        {
            var link = db.Links.SingleOrDefault(x => x.Code == code);

            if (null != link)
            {
                link.HitCount++;
                db.SaveChanges();

                return Redirect(link.URL);
            }

            return HttpNotFound();
        }
	}
}