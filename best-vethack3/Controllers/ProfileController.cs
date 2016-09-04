using best_vethack3.Models;
using best_vethack3.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace best_vethack3.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        [Route("{id:int}")]
        public ActionResult Index(int id=0)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

    }
}