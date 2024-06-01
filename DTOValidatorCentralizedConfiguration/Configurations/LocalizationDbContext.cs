using Microsoft.EntityFrameworkCore;

namespace DTOValidatorCentralizedConfiguration.Configurations
{
    public class LocalizationDbContext : DbContext
    {
        public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<LocalizationResource> LocalizationResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LocalizationResource>().HasKey(x => new { x.Culture, x.Key });

            modelBuilder.Entity<LocalizationResource>().HasData(
                               new LocalizationResource("en-US", "msg_hello", "Hello World!"),
                                              new LocalizationResource("es-ES", "msg_hello", "¡Hola Mundo!")
                                                         );
        }
    }

    public sealed class LocalizationResource
    {
        public string Culture { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }


        public LocalizationResource(string culture, string key, string value)
        {
            Culture = culture;
            Key = key;
            Value = value;
        }
    }
}
