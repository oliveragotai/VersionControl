using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RealEstate
{
    public partial class RealEstateEntities : DbContext
    {
        public RealEstateEntities()
            : base("name=RealEstateEntities")
        {
        }

        public virtual DbSet<Flat> Flats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<Flat>()
                .Property(e => e.Side)
                .IsFixedLength();
        }
    }
}
