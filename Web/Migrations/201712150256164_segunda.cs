namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segunda : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Levels", "RoutineDays", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Levels", "RoutineDays", c => c.Int(nullable: false));
        }
    }
}
