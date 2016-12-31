namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToCarTableInDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Description");
        }
    }
}
