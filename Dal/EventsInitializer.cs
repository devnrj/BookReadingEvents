using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entity;

namespace Dal
{
    public class EventsInitializer : CreateDatabaseIfNotExists<EventsContext>
    {
        protected override void Seed(EventsContext context)
        {

            var userAccount = new List<UserAccount>
            {
                new UserAccount{EmailID="myadmin@bookevents.com",Password="Admin@123"},
                new UserAccount{EmailID="guddu.bhaiya@mirzapur.com",Password="Guddu@123"},

            };
            userAccount.ForEach(x => context.UserAccounts.Add(x));
            context.SaveChanges();
            var user = new List<User>
            {
                new User{FullName="Guddu Pandit",DateOfCreation=DateTime.Now,UserAccount=userAccount[1]},
                new User{FullName="Admin ji",DateOfCreation=DateTime.Now,UserAccount=userAccount[0]},

            };
            user.ForEach(x => context.Users.Add(x));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
