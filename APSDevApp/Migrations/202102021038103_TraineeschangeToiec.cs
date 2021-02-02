namespace APSDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TraineeschangeToiec : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainees", "ToeicScore", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainees", "ToeicScore", c => c.Int(nullable: false));
        }
    }
}
