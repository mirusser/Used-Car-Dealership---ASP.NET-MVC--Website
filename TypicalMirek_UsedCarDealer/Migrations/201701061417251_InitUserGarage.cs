namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitUserGarage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CarId = c.Int(nullable: false),
                        DateOfOrder = c.DateTime(nullable: false),
                        Garage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Garages", t => t.Garage_Id)
                .Index(t => t.UserId)
                .Index(t => t.CarId)
                .Index(t => t.Garage_Id);
            
            CreateTable(
                "dbo.Garages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Garages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "Garage_Id", "dbo.Garages");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "CarId", "dbo.Cars");
            DropIndex("dbo.Garages", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "Garage_Id" });
            DropIndex("dbo.Orders", new[] { "CarId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropTable("dbo.Garages");
            DropTable("dbo.Orders");
        }
    }
}
