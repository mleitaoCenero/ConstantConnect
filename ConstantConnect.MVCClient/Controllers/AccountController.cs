using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstantConnect.MVCClient.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult UserProfile()
        {
            //TODO
            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        public ActionResult LocalLogout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}