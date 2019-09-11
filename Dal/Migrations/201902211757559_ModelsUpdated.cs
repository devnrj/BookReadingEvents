namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Content = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        Event_EventID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Events", t => t.Event_EventID)
                .Index(t => t.Event_EventID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        BookTitle = c.String(),
                        EventTitle = c.String(),
                        StartDate = c.DateTime(),
                        StartTime = c.DateTime(),
                        Duration = c.Int(nullable: false),
                        OrganiserID = c.Int(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        Description = c.String(),
                        Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        EventID = c.Int(nullable: false),
                        InvitationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventID, t.InvitationId })
                .ForeignKey("dbo.Events", t => t.EventID, cascadeDelete: true)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserAccountID = c.Int(nullable: false, identity: true),
                        EmailId = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserAccountID);
            
            AddColumn("dbo.Users", "Guid", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "DateOfCreation", c => c.DateTime());
            AddColumn("dbo.Users", "isAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "UserAccount_UserAccountID", c => c.Int());
            CreateIndex("dbo.Users", "UserAccount_UserAccountID");
            AddForeignKey("dbo.Users", "UserAccount_UserAccountID", "dbo.UserAccounts", "UserAccountID");
            DropColumn("dbo.Users", "EmailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "EmailID", c => c.String());
            DropForeignKey("dbo.Users", "UserAccount_UserAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.Invitations", "EventID", "dbo.Events");
            DropForeignKey("dbo.Comments", "Event_EventID", "dbo.Events");
            DropIndex("dbo.Users", new[] { "UserAccount_UserAccountID" });
            DropIndex("dbo.Invitations", new[] { "EventID" });
            DropIndex("dbo.Comments", new[] { "Event_EventID" });
            DropColumn("dbo.Users", "UserAccount_UserAccountID");
            DropColumn("dbo.Users", "isAdmin");
            DropColumn("dbo.Users", "DateOfCreation");
            DropColumn("dbo.Users", "Guid");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Invitations");
            DropTable("dbo.Events");
            DropTable("dbo.Comments");
        }
    }
}
