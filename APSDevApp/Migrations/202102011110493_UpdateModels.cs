namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Education", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "Education");
        }
    }
}
