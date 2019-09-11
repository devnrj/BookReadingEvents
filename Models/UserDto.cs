using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDto
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public Guid Guid { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public Boolean IsAdmin { get; set; }
        public UserAccountDto UserAccount { get; set; }
    }
}
