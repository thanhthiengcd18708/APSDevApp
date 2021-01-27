namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainees", "Age", c => c.String());
            AddColumn("dbo.Trainees", "DayOfBirth", c => c.String());
            AddColumn("dbo.Trainees", "Education", c => c.String());
            AddColumn("dbo.Trainees", "PrograrmingLanguage", c => c.String());
            AddColumn("dbo.Trainees", "ToeicScore", c => c.Int(nullable: false));
            AddColumn("dbo.Trainees", "Location", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            AddColumn("dbo.Trainers", "Type", c => c.String());
            AddColumn("dbo.Trainers", "WorkingPlace", c => c.String());
            AddColumn("dbo.Trainers", "Email", c => c.Int(nullable: false));
            DropColumn("dbo.Trainees", "Class");
            DropColumn("dbo.Trainees", "Birthday");
            DropColumn("dbo.Trainees", "Address");
            DropColumn("dbo.Trainees", "PhoneNumber");
            DropColumn("dbo.Trainers", "Birthday");
            DropColumn("dbo.Trainers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Address", c => c.String());
            AddColumn("dbo.Trainers", "Birthday", c => c.String());
            AddColumn("dbo.Trainees", "PhoneNumber", c => c.String());
            AddColumn("dbo.Trainees", "Address", c => c.String());
            AddColumn("dbo.Trainees", "Birthday", c => c.String());
            AddColumn("dbo.Trainees", "Class", c => c.String());
            DropColumn("dbo.Trainers", "Email");
            DropColumn("dbo.Trainers", "WorkingPlace");
            DropColumn("dbo.Trainers", "Type");
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.Trainees", "Location");
            DropColumn("dbo.Trainees", "ToeicScore");
            DropColumn("dbo.Trainees", "PrograrmingLanguage");
            DropColumn("dbo.Trainees", "Education");
            DropColumn("dbo.Trainees", "DayOfBirth");
            DropColumn("dbo.Trainees", "Age");
        }
    }
}
