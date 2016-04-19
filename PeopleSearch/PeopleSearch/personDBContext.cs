namespace PeopleSearch
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PersonDBContext : DbContext
    {
        public PersonDBContext()
            : base("name=PeopleContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Interests)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Interests)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);
        }
    }
}
