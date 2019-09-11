namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedInvitationTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Invitations");
            AddColumn("dbo.Invitations", "EmailID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Invitations", new[] { "EventID", "EmailID" });
            DropColumn("dbo.Invitations", "InvitationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invitations", "InvitationId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Invitations");
            DropColumn("dbo.Invitations", "EmailID");
            AddPrimaryKey("dbo.Invitations", new[] { "EventID", "InvitationId" });
        }
    }
}
