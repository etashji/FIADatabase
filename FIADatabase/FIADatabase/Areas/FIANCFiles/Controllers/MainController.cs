using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIADatabase.Areas.FIANCFiles.Controllers
{
    public class MainController : Controller
    {
        // GET: FIANCFiles/Main
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult NCIndex()
        {
            return View();
        }
    }
}