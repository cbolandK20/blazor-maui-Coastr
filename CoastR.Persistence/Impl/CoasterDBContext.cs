using Coastr.Model;
using Microsoft.EntityFrameworkCore;



namespace Coastr.Persistence.Impl
{
    public class CoasterDBContext : DbContext
    {
        public DbSet<Venue> VenueSet { get; set; }
        public DbSet<Menu> MenueSet { get; set; }
        public DbSet<Model.MenuItem> MenuItemSet { get; set; }
        public DbSet<Coaster> CoasterSet { get; set; }
        public DbSet<CoasterItem> CoasterItemSet { get; set; }       
        
        public CoasterDBContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CoastR");
            Directory.CreateDirectory(directoryPath);   
            string dbPath = Path.Combine(directoryPath,"CoastR.db3");
            //string dbPath = "CoastR.db3";

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venue>().ToTable("VENUES")
                .OwnsOne(e => e.Location);
            modelBuilder.Entity<Venue>()
                .HasOne(e => e.Menu)
                .WithOne(e => e.Venue)
                .HasForeignKey<Menu>()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Menu>().ToTable("MENUES")
                .HasMany(e => e.Items)
                .WithOne(e => e.Menu)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Coastr.Model.MenuItem>().ToTable("MENU_ITEMS");

            modelBuilder.Entity<Coaster>().ToTable("COASTERS")
                .HasMany( e => e.Items)
                .WithOne(e => e.Coaster)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CoasterItem>().ToTable("COASTER_ITEMS");
            
        }
    }
}
