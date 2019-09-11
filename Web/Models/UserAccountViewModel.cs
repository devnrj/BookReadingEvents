using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class UserAccountViewModel
    {
        public int UserAccountID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d).{4,12}$")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}