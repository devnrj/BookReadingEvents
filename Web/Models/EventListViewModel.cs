using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventListViewModel
    {
        public List<EventViewModel> PastEvents { get; set; }
        public List<EventViewModel> PresentEvents { get; set; }
        public List<EventViewModel> FutureEvents { get; set; }

        public EventListViewModel(List<EventViewModel> past, 
                                  List<EventViewModel> present, 
                                  List<EventViewModel> future
                                  )
        {
            PastEvents = past;
            PresentEvents = present;
            FutureEvents = future;
        }

        public EventListViewModel()
        {
            PastEvents = new List<EventViewModel>();
            PresentEvents = new List<EventViewModel>();
            FutureEvents = new List<EventViewModel>(); 
        }
    }
}