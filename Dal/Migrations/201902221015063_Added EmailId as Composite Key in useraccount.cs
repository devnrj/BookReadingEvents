namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmailIdasCompositeKeyinuseraccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserAccount_UserAccountID", "dbo.UserAccounts");
            DropIndex("dbo.Users", new[] { "UserAccount_UserAccountID" });
            DropPrimaryKey("dbo.UserAccounts");
            AddColumn("dbo.Users", "UserAccount_EmailID", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserAccounts", "UserAccountID", c => c.Int(nullable: false));
            AlterColumn("dbo.UserAccounts", "EmailID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserAccounts", new[] { "UserAccountID", "EmailID" });
            CreateIndex("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" });
            AddForeignKey("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" }, "dbo.UserAccounts", new[] { "UserAccountID", "EmailID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" }, "dbo.UserAccounts");
            DropIndex("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" });
            DropPrimaryKey("dbo.UserAccounts");
            AlterColumn("dbo.UserAccounts", "EmailID", c => c.String());
            AlterColumn("dbo.UserAccounts", "UserAccountID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "UserAccount_EmailID");
            AddPrimaryKey("dbo.UserAccounts", "UserAccountID");
            CreateIndex("dbo.Users", "UserAccount_UserAccountID");
            AddForeignKey("dbo.Users", "UserAccount_UserAccountID", "dbo.UserAccounts", "UserAccountID");
        }
    }
}
