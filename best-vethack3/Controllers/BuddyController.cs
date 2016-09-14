using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace best_vethack3.Controllers
{
    public class BuddyController : Controller
    {
        public ActionResult Find()
        {
            return View();
        }

        // GET: Profile
        [Route("{id:int}")]
        public ActionResult Profile(int id = 0)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
    }
}