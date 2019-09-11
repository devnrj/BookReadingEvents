namespace Web.Models
{
    public class InvitationViewModel
    {
        public int EventID { get; set; }
        public string EmailID { get; set; }

        public InvitationViewModel() { }
        public InvitationViewModel(int eventid,string emailId)
        {
            EventID = eventid;
            EmailID = emailId;
        }
    }
}