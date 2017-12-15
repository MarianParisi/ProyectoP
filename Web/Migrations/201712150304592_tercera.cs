namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tercera : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Levels", "ID", "dbo.Routines");
            DropIndex("dbo.Levels", new[] { "ID" });
            AddColumn("dbo.Routines", "Level_ID", c => c.Int());
            CreateIndex("dbo.Routines", "Level_ID");
            AddForeignKey("dbo.Routines", "Level_ID", "dbo.Levels", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Routines", "Level_ID", "dbo.Levels");
            DropIndex("dbo.Routines", new[] { "Level_ID" });
            DropColumn("dbo.Routines", "Level_ID");
            CreateIndex("dbo.Levels", "ID");
            AddForeignKey("dbo.Levels", "ID", "dbo.Routines", "ID");
        }
    }
}
