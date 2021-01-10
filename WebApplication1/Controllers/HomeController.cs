using ClassLibrary1.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            home model = new home();
            bool x;
            x=(null== Request.Cookies["userName"]);
            
            
            if (x)model.login = false ;else model.login = true; 

            if (model.login) return View(model);

            else             return View(model);

        }
        

         [Authorize()]
         [ChildActionOnly]
        public ActionResult list()
        {
            
            return PartialView();
        }

        public ActionResult profile()
        {

            string user =Request.Cookies["userName"].Value;
            mycontext data = new mycontext();
            var DB =data.users.FirstOrDefault(m=>m.UserName==user);
            profile pf = new profile();
            pf.ferstname = DB.ferstname;
            pf.LastName = DB.LastName;
            pf.UserName = DB.UserName;
            pf.email = DB.email;
            return View(pf);
        }

    }
}