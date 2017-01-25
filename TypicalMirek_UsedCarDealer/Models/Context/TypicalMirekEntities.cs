using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TypicalMirek_UsedCarDealer.Models.Context
{
    public class TypicalMirekEntities : ApplicationDbContext
    {
        public DbSet<AdditionalData> AdditionalDatas { get; set; }
        public DbSet<AdditionalEquipment> AdditionalEquipments { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gearbox> Gearboxes { get; set; }
        public DbSet<MainData> MainDatas { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CarPhoto> CarsPhotos { get; set; }
        public DbSet<PositionOfSteeringWheel> PositionsOfSteeringWheel { get; set; }
        public DbSet<Propulsion> Propulsions { get; set; }
        public DbSet<SourceOfEnergy> SourcesOfEnergie { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<SliderPhoto> SliderPhotos { get; set; }
        public DbSet<IdentityUserRole> IdentityUserRoles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Garage> UserGarage { get; set; }
        public DbSet<EmailConfiguration> EmailConfigurations { get; set; }
        public DbSet<WebsiteContext> WebsiteContexts { get; set; }
        public DbSet<MarkersConfiguration> MarkersConfiguration { get; set; }
    }
}