namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarAsForeignKeyToSliderPhotoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SliderPhotoes", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.SliderPhotoes", "CarId");
            AddForeignKey("dbo.SliderPhotoes", "CarId", "dbo.Cars", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SliderPhotoes", "CarId", "dbo.Cars");
            DropIndex("dbo.SliderPhotoes", new[] { "CarId" });
            DropColumn("dbo.SliderPhotoes", "CarId");
        }
    }
}
