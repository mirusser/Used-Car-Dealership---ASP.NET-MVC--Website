namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeSomeForeignKeyOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdditionalDatas", "AdditionalEquipmentId", "dbo.AdditionalEquipments");
            DropForeignKey("dbo.AdditionalDatas", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.AdditionalDatas", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AdditionalDatas", "GearboxId", "dbo.Gearboxes");
            DropForeignKey("dbo.AdditionalDatas", "PositionOfSteeringWheelId", "dbo.PositionOfSteeringWheels");
            DropIndex("dbo.AdditionalDatas", new[] { "AdditionalEquipmentId" });
            DropIndex("dbo.AdditionalDatas", new[] { "ColorId" });
            DropIndex("dbo.AdditionalDatas", new[] { "GearboxId" });
            DropIndex("dbo.AdditionalDatas", new[] { "CountryId" });
            DropIndex("dbo.AdditionalDatas", new[] { "PositionOfSteeringWheelId" });
            AlterColumn("dbo.AdditionalDatas", "AdditionalEquipmentId", c => c.Int());
            AlterColumn("dbo.AdditionalDatas", "ColorId", c => c.Int());
            AlterColumn("dbo.AdditionalDatas", "GearboxId", c => c.Int());
            AlterColumn("dbo.AdditionalDatas", "CountryId", c => c.Int());
            AlterColumn("dbo.AdditionalDatas", "PositionOfSteeringWheelId", c => c.Int());
            CreateIndex("dbo.AdditionalDatas", "AdditionalEquipmentId");
            CreateIndex("dbo.AdditionalDatas", "ColorId");
            CreateIndex("dbo.AdditionalDatas", "GearboxId");
            CreateIndex("dbo.AdditionalDatas", "CountryId");
            CreateIndex("dbo.AdditionalDatas", "PositionOfSteeringWheelId");
            AddForeignKey("dbo.AdditionalDatas", "AdditionalEquipmentId", "dbo.AdditionalEquipments", "Id");
            AddForeignKey("dbo.AdditionalDatas", "ColorId", "dbo.Colors", "Id");
            AddForeignKey("dbo.AdditionalDatas", "CountryId", "dbo.Countries", "Id");
            AddForeignKey("dbo.AdditionalDatas", "GearboxId", "dbo.Gearboxes", "Id");
            AddForeignKey("dbo.AdditionalDatas", "PositionOfSteeringWheelId", "dbo.PositionOfSteeringWheels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdditionalDatas", "PositionOfSteeringWheelId", "dbo.PositionOfSteeringWheels");
            DropForeignKey("dbo.AdditionalDatas", "GearboxId", "dbo.Gearboxes");
            DropForeignKey("dbo.AdditionalDatas", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AdditionalDatas", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.AdditionalDatas", "AdditionalEquipmentId", "dbo.AdditionalEquipments");
            DropIndex("dbo.AdditionalDatas", new[] { "PositionOfSteeringWheelId" });
            DropIndex("dbo.AdditionalDatas", new[] { "CountryId" });
            DropIndex("dbo.AdditionalDatas", new[] { "GearboxId" });
            DropIndex("dbo.AdditionalDatas", new[] { "ColorId" });
            DropIndex("dbo.AdditionalDatas", new[] { "AdditionalEquipmentId" });
            AlterColumn("dbo.AdditionalDatas", "PositionOfSteeringWheelId", c => c.Int(nullable: false));
            AlterColumn("dbo.AdditionalDatas", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.AdditionalDatas", "GearboxId", c => c.Int(nullable: false));
            AlterColumn("dbo.AdditionalDatas", "ColorId", c => c.Int(nullable: false));
            AlterColumn("dbo.AdditionalDatas", "AdditionalEquipmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdditionalDatas", "PositionOfSteeringWheelId");
            CreateIndex("dbo.AdditionalDatas", "CountryId");
            CreateIndex("dbo.AdditionalDatas", "GearboxId");
            CreateIndex("dbo.AdditionalDatas", "ColorId");
            CreateIndex("dbo.AdditionalDatas", "AdditionalEquipmentId");
            AddForeignKey("dbo.AdditionalDatas", "PositionOfSteeringWheelId", "dbo.PositionOfSteeringWheels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdditionalDatas", "GearboxId", "dbo.Gearboxes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdditionalDatas", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdditionalDatas", "ColorId", "dbo.Colors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdditionalDatas", "AdditionalEquipmentId", "dbo.AdditionalEquipments", "Id", cascadeDelete: true);
        }
    }
}
