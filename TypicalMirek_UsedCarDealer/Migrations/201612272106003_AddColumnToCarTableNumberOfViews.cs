namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnToCarTableNumberOfViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "numberOfViews", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "numberOfViews");
        }
    }
}
