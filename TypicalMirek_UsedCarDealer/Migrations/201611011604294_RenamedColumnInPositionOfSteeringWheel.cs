namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedColumnInPositionOfSteeringWheel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PositionOfSteeringWheels", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.PositionOfSteeringWheels", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PositionOfSteeringWheels", "Position", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.PositionOfSteeringWheels", "Name");
        }
    }
}
