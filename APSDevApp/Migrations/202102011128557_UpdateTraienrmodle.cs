namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTraienrmodle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "Username");
        }
    }
}
