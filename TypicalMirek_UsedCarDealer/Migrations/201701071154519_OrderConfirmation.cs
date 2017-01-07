namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderConfirmation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "IsInOrder", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "IsConfirmed");
            DropColumn("dbo.Cars", "IsInOrder");
        }
    }
}
