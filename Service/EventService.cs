using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entity;
using Dal.Operations;
using Models;

namespace Service
{
    public class EventService
    {
        static EventOperations eventOperations = new EventOperations();
        public static int GetIdOfLastEvent()
        {
            return eventOperations.GetIdOfLastEvent();
        }


        public static List<EventDto> GetAllEvents()
        {
            return eventOperations.GetAllPublicEvents();
        }

        public static List<EventDto> GetAllPublicEvents()
        {
            
            return eventOperations.GetAllPublicEvents();
        }
        
        public static List<EventDto> GetMyInvitations(int id)
        {
            UserDto user = UserService.GetUserById(id);
            List<InvitationDto> invitations = InvitationService.GetInvitationsByEmailID(user.UserAccount.EmailId);
            List<EventDto> events = new List<EventDto>();
            foreach(InvitationDto invitation in invitations)
            {
                events.Add(GetEventById(invitation.EventID));
            }
            return events;
        }
        public static List<EventDto> GetEventsByOrganiserId(int id)
        {
            return eventOperations.GetEventsByOrganiserId(id);   
        }
        public static EventDto GetEventById(int? id)
        {
            return eventOperations.GetEventById(id);
        }

        public static void CreateEvent(EventDto @event)
        {
            eventOperations.CreateEvent(@event);
        }

        public static void EditEvent(EventDto @event)
        {
            eventOperations.EditEvent(@event);
        }

        public static void DeleteEvent(EventDto @event)
        {
            eventOperations.DeleteEvent(@event);
        }
    }
}
