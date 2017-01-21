namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePathToCarPhotoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarPhotoes", "ImagePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarPhotoes", "ImagePath");
        }
    }
}
