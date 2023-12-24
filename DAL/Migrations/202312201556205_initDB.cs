namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Riders");
        }
    }
}
