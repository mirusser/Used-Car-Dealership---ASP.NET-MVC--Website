namespace TypicalMirek_UsedCarDealer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearOfProduction = c.Int(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                        NumberOfOwners = c.Int(nullable: false),
                        EngineCapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FuelTankCapacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EnginePower = c.Int(),
                        Length = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mass = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Milleage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Damaged = c.Boolean(nullable: false),
                        AdditionalEquipmentId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        GearboxId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        PositionOfSteeringWheelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdditionalEquipments", t => t.AdditionalEquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Gearboxes", t => t.GearboxId, cascadeDelete: true)
                .ForeignKey("dbo.PositionOfSteeringWheels", t => t.PositionOfSteeringWheelId, cascadeDelete: true)
                .Index(t => t.AdditionalEquipmentId)
                .Index(t => t.ColorId)
                .Index(t => t.GearboxId)
                .Index(t => t.CountryId)
                .Index(t => t.PositionOfSteeringWheelId);
            
            CreateTable(
                "dbo.AdditionalEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Climatisation = c.Boolean(),
                        AdditionalWheels = c.Boolean(),
                        Towbar = c.Boolean(),
                        Radio = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gearboxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PositionOfSteeringWheels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainDataId = c.Int(nullable: false),
                        BodyId = c.Int(nullable: false),
                        PropulsionId = c.Int(nullable: false),
                        SourceOfEnergyId = c.Int(nullable: false),
                        AdditionalDataId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdditionalDatas", t => t.AdditionalDataId, cascadeDelete: true)
                .ForeignKey("dbo.Bodies", t => t.BodyId, cascadeDelete: true)
                .ForeignKey("dbo.MainDatas", t => t.MainDataId, cascadeDelete: true)
                .ForeignKey("dbo.Propulsions", t => t.PropulsionId, cascadeDelete: true)
                .ForeignKey("dbo.SourceOfEnergies", t => t.SourceOfEnergyId, cascadeDelete: true)
                .Index(t => t.MainDataId)
                .Index(t => t.BodyId)
                .Index(t => t.PropulsionId)
                .Index(t => t.SourceOfEnergyId)
                .Index(t => t.AdditionalDataId);
            
            CreateTable(
                "dbo.MainDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId)
                .Index(t => t.CharacterId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Version = c.String(),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Image = c.Binary(nullable: false),
                        Car_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.Propulsions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SourceOfEnergies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cars", "SourceOfEnergyId", "dbo.SourceOfEnergies");
            DropForeignKey("dbo.Cars", "PropulsionId", "dbo.Propulsions");
            DropForeignKey("dbo.Photos", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.Cars", "MainDataId", "dbo.MainDatas");
            DropForeignKey("dbo.MainDatas", "TypeId", "dbo.Types");
            DropForeignKey("dbo.MainDatas", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.MainDatas", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Cars", "BodyId", "dbo.Bodies");
            DropForeignKey("dbo.Cars", "AdditionalDataId", "dbo.AdditionalDatas");
            DropForeignKey("dbo.AdditionalDatas", "PositionOfSteeringWheelId", "dbo.PositionOfSteeringWheels");
            DropForeignKey("dbo.AdditionalDatas", "GearboxId", "dbo.Gearboxes");
            DropForeignKey("dbo.AdditionalDatas", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.AdditionalDatas", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.AdditionalDatas", "AdditionalEquipmentId", "dbo.AdditionalEquipments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Photos", new[] { "Car_Id" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropIndex("dbo.MainDatas", new[] { "ModelId" });
            DropIndex("dbo.MainDatas", new[] { "CharacterId" });
            DropIndex("dbo.MainDatas", new[] { "TypeId" });
            DropIndex("dbo.Cars", new[] { "AdditionalDataId" });
            DropIndex("dbo.Cars", new[] { "SourceOfEnergyId" });
            DropIndex("dbo.Cars", new[] { "PropulsionId" });
            DropIndex("dbo.Cars", new[] { "BodyId" });
            DropIndex("dbo.Cars", new[] { "MainDataId" });
            DropIndex("dbo.AdditionalDatas", new[] { "PositionOfSteeringWheelId" });
            DropIndex("dbo.AdditionalDatas", new[] { "CountryId" });
            DropIndex("dbo.AdditionalDatas", new[] { "GearboxId" });
            DropIndex("dbo.AdditionalDatas", new[] { "ColorId" });
            DropIndex("dbo.AdditionalDatas", new[] { "AdditionalEquipmentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.SourceOfEnergies");
            DropTable("dbo.Propulsions");
            DropTable("dbo.Photos");
            DropTable("dbo.Types");
            DropTable("dbo.Models");
            DropTable("dbo.Characters");
            DropTable("dbo.MainDatas");
            DropTable("dbo.Cars");
            DropTable("dbo.Brands");
            DropTable("dbo.Bodies");
            DropTable("dbo.PositionOfSteeringWheels");
            DropTable("dbo.Gearboxes");
            DropTable("dbo.Countries");
            DropTable("dbo.Colors");
            DropTable("dbo.AdditionalEquipments");
            DropTable("dbo.AdditionalDatas");
        }
    }
}
