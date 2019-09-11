using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EventDto
    {
        public int EventID { get; set; }
        public string Location { get; set; }
        public string BookTitle { get; set; }
        public string EventTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int OrganiserID { get; set; }
        public Boolean IsPublic { get; set; }
        public string Description { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<InvitationDto> Invitations { get; set; }
        public Guid Guid { get; set; }
        
    }
}
