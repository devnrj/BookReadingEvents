using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using Service;
using Web.Models;
using Web.Helper;
using Web.Filters;

namespace Web.Controllers
{
    [UserAuthenticationFilter]
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            List<EventDto> events;
            if (((UserViewModel)Session["UserData"]).IsAdmin == true)
            {
                events = EventService.GetAllEvents();
            }
            else
            {
                events=EventService.GetEventsByOrganiserId(((UserViewModel)Session["UserData"]).UserID);
            }
            switch (sortOrder)
            {
                case "date_desc" :
                   events=events.OrderByDescending(e => e.StartDate).ToList();
                    break;
                case "Date":
                    events= events.OrderBy(e => e.StartDate).ToList();
                    break;
                default:
                    events= events.OrderByDescending(e => e.StartDate).ToList();
                    break;
            }
            return View(Mapper.ToEventViewModelList(events));
        }

        // GET: Event/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDto @event = EventService.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();

            }
            if(Session["UserData"]==null && @event.IsPublic == false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(Mapper.ToEventViewModel(@event));
        }
        
        public ActionResult AddComment([Bind (Include="EventID, Comment")] EventViewModel @event)
        {
            if (@event == null)
            {
                return HttpNotFound();
            }

            int id = ((UserViewModel)Session["UserData"]).UserID;
            CommentViewModel comment = new CommentViewModel(id, @event.Comment, DateTime.Now);
            @event = Mapper.ToEventViewModel(EventService.GetEventById(@event.EventID));
            
            if (@event.Comments == null)
            {
                @event.Comments = new List<CommentViewModel>();
            }
            @event.Comments.Add(comment);
            EventService.EditEvent(Mapper.ToEventDto(@event));
            return View("Details",@event);
        }
        
        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Location,BookTitle,EventTitle,StartDate,StartTime,Duration,IsPublic,Description,Invites")] EventViewModel @event)
        {
            if (ModelState.IsValid)
            {
                @event.Guid = Guid.NewGuid();
                @event.OrganiserID = ((UserViewModel)Session["UserData"]).UserID;
                List<InvitationViewModel> invites = new List<InvitationViewModel>();
                @event.EventID = EventService.GetIdOfLastEvent() + 1;
                foreach (String invite in @event.Invites.Split(','))
                {
                    invites.Add(new InvitationViewModel(EventService.GetIdOfLastEvent() + 1, invite));
                }
                @event.Invitations = invites;
                EventService.CreateEvent(Mapper.ToEventDto(@event));
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        public ActionResult Invitation()
        {
            int id = 0;
            if (Session["UserData"] == null){
                return View("Index", "Home");
            } else{
                id = ((UserViewModel)Session["UserData"]).UserID;
            }

            List<EventViewModel> events = Mapper.ToEventViewModelList(EventService.GetMyInvitations((id)));
            return View(events);
        }
        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventViewModel @event = Mapper.ToEventViewModel(EventService.GetEventById(id));
            if (@event == null)
            {
                return HttpNotFound();
            }
            else
            {
                EventService.EditEvent(Mapper.ToEventDto(@event));
            }

            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Location,BookTitle,EventTitle,StartDate,StartTime,Duration,IsPublic,Description,Invites")] EventViewModel @event)
        {
            if (ModelState.IsValid)
            {
                EventService.EditEvent(Mapper.ToEventDto(@event));
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventViewModel @event = Mapper.ToEventViewModel(EventService.GetEventById(id));
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            EventDto @event = EventService.GetEventById(id);
            EventService.DeleteEvent(@event);
            return RedirectToAction("Index");
        }

    }
}
