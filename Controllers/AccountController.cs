using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Authentication_Authorization_Examp.Models;

namespace Authentication_Authorization_Examp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            MyOrgEntities MOE = new MyOrgEntities();
            var count = MOE.Users.Where(x=>x.UserName==u.UserName && x.pwd==u.pwd ).Count();
            if(count==0)
            {
                ViewBag.Msg = "Invalid User";
                return View();
            }
            else
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}