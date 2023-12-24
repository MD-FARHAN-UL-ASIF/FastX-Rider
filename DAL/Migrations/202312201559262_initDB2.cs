namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Riders", "Created_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Riders", "Created_at");
        }
    }
}
