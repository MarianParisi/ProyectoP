namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExerciseTypeID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ExerciseTypes", t => t.ExerciseTypeID, cascadeDelete: true)
                .Index(t => t.ExerciseTypeID);
            
            CreateTable(
                "dbo.ExerciseRoutines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoutineID = c.Int(nullable: false),
                        ExerciseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseID, cascadeDelete: true)
                .ForeignKey("dbo.Routines", t => t.RoutineID, cascadeDelete: true)
                .Index(t => t.RoutineID)
                .Index(t => t.ExerciseID);
            
            CreateTable(
                "dbo.Routines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Rounds = c.Int(nullable: false),
                        ExerciseNumber = c.Int(nullable: false),
                        RoutineDays = c.Int(nullable: false),
                        ExerciseRepetition = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Routines", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ExerciseTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "ExerciseTypeID", "dbo.ExerciseTypes");
            DropForeignKey("dbo.Routines", "UserID", "dbo.Users");
            DropForeignKey("dbo.Levels", "ID", "dbo.Routines");
            DropForeignKey("dbo.ExerciseRoutines", "RoutineID", "dbo.Routines");
            DropForeignKey("dbo.ExerciseRoutines", "ExerciseID", "dbo.Exercises");
            DropIndex("dbo.Levels", new[] { "ID" });
            DropIndex("dbo.Routines", new[] { "UserID" });
            DropIndex("dbo.ExerciseRoutines", new[] { "ExerciseID" });
            DropIndex("dbo.ExerciseRoutines", new[] { "RoutineID" });
            DropIndex("dbo.Exercises", new[] { "ExerciseTypeID" });
            DropTable("dbo.ExerciseTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Levels");
            DropTable("dbo.Routines");
            DropTable("dbo.ExerciseRoutines");
            DropTable("dbo.Exercises");
        }
    }
}
