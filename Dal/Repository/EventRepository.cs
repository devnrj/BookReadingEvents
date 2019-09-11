using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Helper;
using Models;
using Dal;
using Dal.Entity;
using System.Data.Entity;

namespace Dal.Operations
{
    public class EventOperations
    {
        EventsContext _dbContext = new EventsContext();

        public List<EventDto> GetAllPublicEvents()
        {
            return Mapper.ToEventDtoList(_dbContext.Events.Where(x => x.IsPublic == true).ToList());
        }
        public List<EventDto> GetAllEvents()
        {
            return Mapper.ToEventDtoList(_dbContext.Events.ToList());
        }
        public List<EventDto> GetMyInvitations(int id)
        {
            var result = (from u in _dbContext.Users
                                               join i in _dbContext.Invitations on u.UserAccount.EmailID equals i.EmailID
                                               join e in _dbContext.Events on i.EventID equals e.EventID
                                               where u.UserID == id
                                               select new
                                               {
                                                   e.EventID,
                                                   e.BookTitle,
                                                   e.EventTitle,
                                                   e.Duration,
                                                   e.StartDate,
                                                   e.StartTime,
                                                   e.Location,
                                                   e.IsPublic,
                                                   e.Description
                                               }).ToList().Select(
                                                  e => new Event
                                                  {
                                                      EventID = e.EventID,
                                                      BookTitle = e.BookTitle,
                                                      EventTitle = e.EventTitle,
                                                      Duration = e.Duration,
                                                      StartDate = e.StartDate,
                                                      StartTime = e.StartTime,
                                                      Location = e.Location,
                                                      IsPublic = e.IsPublic,
                                                      Description = e.Description
                                                  });
            return Mapper.ToEventDtoList(result as List<Event>);
        }
        public int GetIdOfLastEvent()
        {
            int id = 0;
            if(_dbContext.Events.Count()!=0)
            {
                id =_dbContext.Events.OrderByDescending(x => x.EventID).First().EventID;
            }
            return id;
        }

        public EventDto GetEventById(int? id)
        {
            return Mapper.ToEventDto(_dbContext.Events.Find(id));
        }

        public void CreateEvent(EventDto Event)
        {
            _dbContext.Events.Add(Mapper.ToEvent(Event));
            _dbContext.SaveChanges();
        }

        public void DeleteEvent(EventDto Event)
        {
            _dbContext.Events.Remove(Mapper.ToEvent(Event));
            _dbContext.SaveChanges();
        }

        public List<EventDto> GetEventsByOrganiserId(int id)
        {
            return Mapper.ToEventDtoList(_dbContext.Events.Where(events => events.OrganiserID == id).ToList());
        }
        public void EditEvent(EventDto edto)
        {
            Event @event = Mapper.ToEvent(edto);
            Event temp = _dbContext.Events.First(x => x.EventID == @event.EventID);
            temp.Comments = @event.Comments;
            //_dbContext.Entry(@event).Property("Comments").IsModified=true;
            _dbContext.SaveChanges();
        }
    }
}
