using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entity
{
    public class Invitation
    {
        [Key, Column(Order = 0)]
        public int EventID { get; set; }
        [Key, Column(Order = 1)]
        public string EmailID { get; set; }
    }
}