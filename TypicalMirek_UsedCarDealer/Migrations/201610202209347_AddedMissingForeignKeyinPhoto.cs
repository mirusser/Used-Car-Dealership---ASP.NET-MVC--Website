namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMissingForeignKeyinPhoto : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "Car_Id", "dbo.Cars");
            DropIndex("dbo.Photos", new[] { "Car_Id" });
            RenameColumn(table: "dbo.Photos", name: "Car_Id", newName: "CarId");
            AlterColumn("dbo.Photos", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "CarId");
            AddForeignKey("dbo.Photos", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "CarId", "dbo.Cars");
            DropIndex("dbo.Photos", new[] { "CarId" });
            AlterColumn("dbo.Photos", "CarId", c => c.Int());
            RenameColumn(table: "dbo.Photos", name: "CarId", newName: "Car_Id");
            CreateIndex("dbo.Photos", "Car_Id");
            AddForeignKey("dbo.Photos", "Car_Id", "dbo.Cars", "Id");
        }
    }
}
