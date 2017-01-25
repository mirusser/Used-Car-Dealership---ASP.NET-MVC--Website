namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShopsLocationToGoogleMapsPlugin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarkersConfigurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMarker = c.Boolean(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Title = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.WebsiteContexts");
            DropTable("dbo.MarkersConfigurations");
            DropTable("dbo.EmailConfigurations");
        }
    }
}
