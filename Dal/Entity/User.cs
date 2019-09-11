using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entity
{

    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string FullName { get; set; }
        public Guid Guid { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfCreation { get; set; }
        public Boolean IsAdmin { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
