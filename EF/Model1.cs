namespace EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MyDB")
        {
        }

        public virtual DbSet<T1> T1 { get; set; }
        public virtual DbSet<T2> T2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T1>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<T1>()
                .HasMany(e => e.T11)
                .WithRequired(e => e.T12)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<T1>()
                .HasMany(e => e.T2)
                .WithOptional(e => e.T1)
                .HasForeignKey(e => e.TId);
        }
    }
}
