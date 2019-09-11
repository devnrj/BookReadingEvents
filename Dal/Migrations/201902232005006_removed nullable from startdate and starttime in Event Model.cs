namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednullablefromstartdateandstarttimeinEventModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Events", "StartDate", c => c.DateTime());
        }
    }
}
