namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedcompositekeyfromemailidinuserAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" }, "dbo.UserAccounts");
            DropIndex("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" });
            DropPrimaryKey("dbo.UserAccounts");
            AlterColumn("dbo.UserAccounts", "UserAccountID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserAccounts", "EmailID", c => c.String());
            AddPrimaryKey("dbo.UserAccounts", "UserAccountID");
            CreateIndex("dbo.Users", "UserAccount_UserAccountID");
            AddForeignKey("dbo.Users", "UserAccount_UserAccountID", "dbo.UserAccounts", "UserAccountID");
            DropColumn("dbo.Users", "UserAccount_EmailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserAccount_EmailID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Users", "UserAccount_UserAccountID", "dbo.UserAccounts");
            DropIndex("dbo.Users", new[] { "UserAccount_UserAccountID" });
            DropPrimaryKey("dbo.UserAccounts");
            AlterColumn("dbo.UserAccounts", "EmailID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserAccounts", "UserAccountID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserAccounts", new[] { "UserAccountID", "EmailID" });
            CreateIndex("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" });
            AddForeignKey("dbo.Users", new[] { "UserAccount_UserAccountID", "UserAccount_EmailID" }, "dbo.UserAccounts", new[] { "UserAccountID", "EmailID" });
        }
    }
}
