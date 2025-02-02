using System.Data.Entity;
using NinjaDomain.Classes;

namespace NinjaDomain.DataModel
{
    public class NinjaContext:DbContext
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipment { get; set; }


        // Configuring one-to-many foreigh key rather 0..1-to-many foreign key.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NinjaEquipment>()
                .HasRequired(e => e.Ninja)
                .WithMany(n => n.EquipmentOwned);
        }
    }
}
