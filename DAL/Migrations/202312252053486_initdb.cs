namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        PackageId = c.Int(nullable: false),
                        LastUpdatedBy = c.Int(nullable: false),
                        Rider_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId, cascadeDelete: true)
                .ForeignKey("dbo.Riders", t => t.Rider_Id)
                .Index(t => t.PackageId)
                .Index(t => t.Rider_Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Weight = c.Double(nullable: false),
                        DestinationAddress = c.String(nullable: false),
                        ShippingMehtod = c.Int(nullable: false),
                        Insurance = c.Boolean(),
                        EntitmatedDelivery = c.DateTime(nullable: false),
                        DiliveryManId = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        PymentMethod = c.Int(nullable: false),
                        Retuned = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Riders", t => t.DiliveryManId, cascadeDelete: true)
                .Index(t => t.DiliveryManId);
            
            CreateTable(
                "dbo.Riders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        NID = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Station = c.String(),
                        VehicaleType = c.String(),
                        Salary = c.Double(nullable: false),
                        Status = c.String(),
                        Created_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeliveryStatus", "Rider_Id", "dbo.Riders");
            DropForeignKey("dbo.DeliveryStatus", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Packages", "DiliveryManId", "dbo.Riders");
            DropIndex("dbo.Packages", new[] { "DiliveryManId" });
            DropIndex("dbo.DeliveryStatus", new[] { "Rider_Id" });
            DropIndex("dbo.DeliveryStatus", new[] { "PackageId" });
            DropTable("dbo.Riders");
            DropTable("dbo.Packages");
            DropTable("dbo.DeliveryStatus");
        }
    }
}
