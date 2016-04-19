///By: Salvatore Stone Mele
///4/19/16


namespace PeopleSearch
{
    using System.Data.Entity;

    //Class used to set up the entity database. 
    public partial class PersonDBContext : DbContext
    {
        public PersonDBContext()
            : base("name=PeopleContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }

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
        }
    }
}
