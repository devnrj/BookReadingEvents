using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repository;
using Models;

namespace Service
{
    public class InvitationService
    {
        
        public static List<InvitationDto> GetInvitationsByEmailID(string emailId)
        {
            return InvitationRepository.GetGetInvitationsByEmailID(emailId);
        }
    }
}
