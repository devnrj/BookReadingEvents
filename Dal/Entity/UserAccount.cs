using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entity
{

    public class UserAccount
    {
        [Key]
        public int UserAccountID { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
    }
}