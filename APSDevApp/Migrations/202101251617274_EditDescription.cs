namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Courses", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "Dc");
            DropColumn("dbo.Courses", "Dc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Dc", c => c.String(nullable: false));
            AddColumn("dbo.Categories", "Dc", c => c.String(nullable: false));
            DropColumn("dbo.Courses", "Description");
            DropColumn("dbo.Categories", "Description");
        }
    }
}
