using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entity
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public string Location { get; set; }
        public string BookTitle { get; set; }
        public string EventTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int OrganiserID { get; set; }
        public Boolean IsPublic { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Invitation> Invitations { get; set; }
        public Guid Guid { get; set; }
    }
}
