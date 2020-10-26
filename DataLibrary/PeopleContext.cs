using EFCore5.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace EFCore5.Data
{
  public class PeopleContext : DbContext
  {
    public PeopleContext()
    {

    }
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<WildlifeSighting> WildlifeSightings { get; set; }
    public DbSet<ScaryWildlifeSighting> ScaryWildlifeSightings { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var myconnectionstring="Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PeopleDbEFCore5";
            optionsBuilder.UseSqlServer(myconnectionstring)
              .LogTo(Console.WriteLine,
                     new[] { DbLoggerCategory.Database.Command.Name },
                     LogLevel.Information);          
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            #region LaterDemos
             // modelBuilder.Entity<ScaryWildlifeSighting>().ToTable("ScarySightings");
          
            //modelBuilder.Entity<Person>()
            //    .HasMany(p => p.Addresses)
            //    .WithMany(a => a.Residents)
            //    .UsingEntity<Resident>(
            //    r => r.HasOne<Address>().WithMany(),
            //    r => r.HasOne<Person>().WithMany())
            //    .Property(r => r.MovedInDate)
            //      .HasDefaultValueSql("getdate()");
          
            //modelBuilder.Entity<Resident>().ToTable("AddressPerson");
            #endregion

            modelBuilder.Entity<Person>().HasData(
         new Person { Id = 1, FirstName = "Julie", LastName = "Lerman" },
         new Person { Id = 2, FirstName = "Husband of", LastName = "Julie" },
         new Person { Id = 3, FirstName = "Brice", LastName = "Lambson" },
         new Person { Id = 4, FirstName = "Arthur", LastName = "Vickers" });
      modelBuilder.Entity<Address>().HasData(
        new Address { Id = 1, Street = "1 Main", PostalCode = "11111" },
        new Address { Id = 2, Street = "2 Main", PostalCode = "22222" },
        new Address { Id = 3, Street = "3 Main", PostalCode = "3333" });

            var thedate = new DateTime(2020, 10, 29);
            modelBuilder.Entity<WildlifeSighting>().HasData(
        new WildlifeSighting {Id=1, AddressId = 1, DateTime = thedate, Description = "Bear" },
        new WildlifeSighting {Id=2, AddressId = 1, DateTime = thedate, Description = "Bear Cub #1" },
        new WildlifeSighting {Id=3, AddressId = 1, DateTime = thedate, Description = "Bear Cub #2" },
        new WildlifeSighting {Id=4, AddressId = 1, DateTime = thedate, Description = "Bear Cub #3" },
        new WildlifeSighting {Id=5, AddressId = 1, DateTime = thedate, Description = "Squirrel" },
        new WildlifeSighting {Id=6, AddressId = 1, DateTime = thedate, Description = "Garter Snake" });
     
    }
  }
}