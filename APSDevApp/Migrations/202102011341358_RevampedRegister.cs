namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevampedRegister : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trainees", "Name");
            DropColumn("dbo.Trainers", "Username");
            DropColumn("dbo.Trainers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Name", c => c.String());
            AddColumn("dbo.Trainers", "Username", c => c.String());
            AddColumn("dbo.Trainees", "Name", c => c.String());
        }
    }
}
