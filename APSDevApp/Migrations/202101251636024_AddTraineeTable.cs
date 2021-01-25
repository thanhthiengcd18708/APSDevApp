namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTraineeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trainees",
                c => new
                    {
                        TraineeId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Class = c.String(),
                        Birthday = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TraineeId)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.TraineeId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainees", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainees", "TraineeId", "dbo.AspNetUsers");
            DropIndex("dbo.Trainees", new[] { "CourseId" });
            DropIndex("dbo.Trainees", new[] { "TraineeId" });
            DropTable("dbo.Trainees");
        }
    }
}
