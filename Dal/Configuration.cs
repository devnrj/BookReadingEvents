using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public sealed class Configuration : DbMigrationsConfiguration<EventsContext>
    {
        public void RunSeed()
        {
            Configuration configuration = new Configuration();
            configuration.ContextType = typeof(YourContextClassHere);
            var migrator = new DbMigrator(configuration);

            //This will get the SQL script which will update the DB and write it to debug
            var scriptor = new MigratorScriptingDecorator(migrator);
            string script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null).ToString();
            Debug.Write(script);

            //This will run the migration update script and will run Seed() method
            migrator.Update();
        }
        
    }
}
