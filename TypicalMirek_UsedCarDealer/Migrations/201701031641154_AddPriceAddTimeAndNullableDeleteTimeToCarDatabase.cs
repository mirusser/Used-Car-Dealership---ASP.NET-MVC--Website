namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceAddTimeAndNullableDeleteTimeToCarDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Cars", "AddTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "DeleteTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "DeleteTime");
            DropColumn("dbo.Cars", "AddTime");
            DropColumn("dbo.Cars", "Price");
        }
    }
}
