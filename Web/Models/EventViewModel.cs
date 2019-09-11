using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EventViewModel
    {
        public int EventID { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string EventTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [Required]
        [Range(0,4)]
        public int Duration { get; set; }
        [Required]
        public int OrganiserID { get; set; }
        [Required]
        public Boolean IsPublic { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(500)]
        public string OtherDetails { get; set; }
        public virtual List<CommentViewModel> Comments { get; set; }

        //[DataType(DataType.EmailAddress)]
        [RegularExpression(@"(([a - zA - Z\-0 - 9\.]+@)([a - zA - Z\-0 - 9\.]+)[,]*)+")]
        public string Invites { get; set; }
        public string Comment { get; set; }
        public virtual List<InvitationViewModel> Invitations { get; set; }
        public Guid Guid { get; set; }
    }
}