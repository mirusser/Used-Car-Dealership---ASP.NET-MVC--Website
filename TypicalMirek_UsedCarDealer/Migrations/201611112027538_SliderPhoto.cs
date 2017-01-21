namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class SliderPhoto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SliderPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarPhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarPhotoes", t => t.CarPhotoId, cascadeDelete: true)
                .Index(t => t.CarPhotoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderPhotoes", "CarPhotoId", "dbo.CarPhotoes");
            DropIndex("dbo.SliderPhotoes", new[] { "CarPhotoId" });
            DropTable("dbo.SliderPhotoes");
        }
    }
}
