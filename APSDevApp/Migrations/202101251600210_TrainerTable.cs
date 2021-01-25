namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Birthday = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerId)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.TrainerId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.Trainers", new[] { "CourseId" });
            DropIndex("dbo.Trainers", new[] { "TrainerId" });
            DropTable("dbo.Trainers");
        }
    }
}
