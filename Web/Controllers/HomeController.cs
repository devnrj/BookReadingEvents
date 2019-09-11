using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Service;
using Web.Helper;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EventListViewModel Events = new EventListViewModel();
            foreach (EventDto @event in EventService.GetAllPublicEvents())
            {
                if (@event.StartDate > DateTime.Now)
                {
                    Events.FutureEvents.Add( Mapper.ToEventViewModel(@event));
                } else if (@event.StartDate < DateTime.Now)
                {
                    Events.PastEvents.Add(Mapper.ToEventViewModel(@event));
                } else if (@event.StartDate == DateTime.Now)
                {
                    Events.PresentEvents.Add(Mapper.ToEventViewModel(@event));
                }
            }

            return View(Events);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void CustomerSupport()
        {
            Response.Redirect("helpdesk.nagarro.com");
        }
    }
}