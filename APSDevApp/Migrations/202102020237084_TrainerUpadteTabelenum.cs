namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerUpadteTabelenum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Type", c => c.String());
        }
    }
}
