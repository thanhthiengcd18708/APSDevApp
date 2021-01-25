namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Dc", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Dc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Dc", c => c.String());
            AlterColumn("dbo.Categories", "Dc", c => c.String());
        }
    }
}
