using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstantConnect.MVCClient.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult CreateNewTicket()
        {
            return View();
        }

        public ActionResult OpenTickets()
        {
            return View();
        }
        public ActionResult ResolvedTickets()
        {
            return View();
        }
        public ActionResult WarrantyInformation()
        {
            return View();
        }
    }
}