namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trainernewtable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trainers", "Education");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Education", c => c.String());
        }
    }
}
