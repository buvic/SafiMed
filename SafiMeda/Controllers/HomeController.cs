using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Web.Mvc;
using SafiMed.Models;

namespace SafiMed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            ViewBag.Action = "Home";

            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Action = "AboutUs";
            return View();
        }

        public ActionResult Cooperation(string tab)
        {
            ViewBag.Action = "Cooperation";
            switch (tab)
            {
                case "consalting":
                case "marketing":
                case "benefits":
                    ViewBag.ActiveTab = tab;
                    break;
                default:
                    ViewBag.ActiveTab = "principles";
                    break;
            }

            var filtered = new NameValueCollection(Request.QueryString);
            filtered.Remove("tab");

            return View();
        }

        public ActionResult Contact(bool? isSend)
        {
            ViewBag.Action = "Contact";
            ViewBag.isSend = isSend ?? false;
            ViewBag.isError = false;
            return View(new FeedbackResponse());
        }

        [HttpPost]
        public ActionResult ChangeCulture(string lang)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Json(true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(FeedbackResponse response)
        {
            ViewBag.Action = "Contact";
            ViewBag.isSend = false;
            ViewBag.isError = false;

            if (ModelState.IsValid)
            {
                try
                {
                    var mailSender = new EmailSender();
                    mailSender.Send(response);

                    ViewBag.isSend = true;
                    ViewBag.isError = false;
                    return RedirectToAction("Contact", "Home", new {isSend = true});

                }
                catch (Exception e)
                {
                    ViewBag.isError = true;
                    return View(response);
                }
            }

            return View(response);
        }
    }
}
