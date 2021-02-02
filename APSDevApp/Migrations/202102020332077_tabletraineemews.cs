namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabletraineemews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainees", "Experience", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainees", "Experience");
        }
    }
}
