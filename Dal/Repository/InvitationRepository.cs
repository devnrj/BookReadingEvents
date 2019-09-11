using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Helper;
using Models;

namespace Dal.Repository
{
    public class InvitationRepository
    {
        static EventsContext _dbContext = new EventsContext();
        public static List<InvitationDto> GetGetInvitationsByEmailID(string emailId)
        {
            return Mapper.ToInvitationDtoList(_dbContext.Invitations.Where(x=>x.EmailID == emailId).ToList());
        }
    }
}
