namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullToAdditionalDataInCarModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "AdditionalDataId", "dbo.AdditionalDatas");
            DropIndex("dbo.Cars", new[] { "AdditionalDataId" });
            AlterColumn("dbo.Cars", "AdditionalDataId", c => c.Int());
            CreateIndex("dbo.Cars", "AdditionalDataId");
            AddForeignKey("dbo.Cars", "AdditionalDataId", "dbo.AdditionalDatas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "AdditionalDataId", "dbo.AdditionalDatas");
            DropIndex("dbo.Cars", new[] { "AdditionalDataId" });
            AlterColumn("dbo.Cars", "AdditionalDataId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "AdditionalDataId");
            AddForeignKey("dbo.Cars", "AdditionalDataId", "dbo.AdditionalDatas", "Id", cascadeDelete: true);
        }
    }
}
