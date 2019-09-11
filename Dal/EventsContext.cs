using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Entity;

namespace Dal
{
    public class EventsContext : DbContext
    {
        public EventsContext() : base("EventsContext")
        {
            Database.SetInitializer(new EventsInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
