namespace EmailSenderMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Emails", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Emails", new[] { "UserId" });
            AlterColumn("dbo.Emails", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Emails", "UserId");
            AddForeignKey("dbo.Emails", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Emails", new[] { "UserId" });
            AlterColumn("dbo.Emails", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Emails", "UserId");
            AddForeignKey("dbo.Emails", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
