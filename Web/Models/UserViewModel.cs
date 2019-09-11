using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserViewModel
    {

        public int UserID { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public string FullName { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public Boolean IsAdmin { get; set; }
        public UserAccountViewModel UserAccount { get; set; }
        public Guid Guid { get; set; }
    }
}