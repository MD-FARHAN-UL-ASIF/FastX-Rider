namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontextUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeliveryStatus", "Rider_Id", "dbo.Riders");
            DropIndex("dbo.DeliveryStatus", new[] { "Rider_Id" });
            AlterColumn("dbo.DeliveryStatus", "LastUpdatedBy", c => c.Int());
            DropColumn("dbo.DeliveryStatus", "Rider_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeliveryStatus", "Rider_Id", c => c.Int());
            AlterColumn("dbo.DeliveryStatus", "LastUpdatedBy", c => c.Int(nullable: false));
            CreateIndex("dbo.DeliveryStatus", "Rider_Id");
            AddForeignKey("dbo.DeliveryStatus", "Rider_Id", "dbo.Riders", "Id");
        }
    }
}
