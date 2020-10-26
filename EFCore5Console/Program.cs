using EFCore5.Data;
using EFCore5.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCore5Console
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            using (var context = new PeopleContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }


            Console.Clear();
            //InsertM2M();
            //QueryM2M();
            //QueryResidents();
            FilteredInclude();
            // SplitQueryInclude();
            //TPTWork();
            Console.ReadKey();
        }

        private static void QueryResidents()
        {
            using var context = new PeopleContext();
            foreach (var r in context.Set<Resident>())
            {
                Console.WriteLine($"{r.PersonId},{r.AddressId},{r.MovedInDate}");
            }


        }

        private static void InsertM2M()
        {
            //joining first 2 people to first 2 addresses
            using var context = new PeopleContext();
            var people = context.People.Skip(0).Take(2).ToList();
            var addresses = context.Addresses.Skip(0).Take(2).ToList();
            people[0].Addresses.AddRange(addresses);
            people[1].Addresses.AddRange(addresses);
            context.SaveChanges();
        }

        private static void QueryM2M()
        {
            using var context = new PeopleContext();
            foreach (var p in context.People.Include(p => p.Addresses))
            {
                Console.WriteLine(p.FirstName);
                foreach (var a in p.Addresses)
                {
                    Console.WriteLine($"**{a.Street}");
                }
            }
        }

   

        private static void FilteredInclude()
        {
            using (var context = new PeopleContext())
            {
                var tag = "No Filter/Sort";
                var address = context.Addresses.TagWith(tag).Include(a => a.WildlifeSightings).FirstOrDefault();
                OutPutWildlife(address);

                context.ChangeTracker.Clear();
                tag = "Filter: Bears";
                var a_bears = context.Addresses.TagWith(tag)
                    .Include(a => a.WildlifeSightings.Where(w => w.Description.Contains("Bear")))
                .FirstOrDefault();
                OutPutWildlife(a_bears);

                context.ChangeTracker.Clear();
                tag="Filter and Sort: No Bears";
                var a_nobears = context.Addresses.TagWith(tag)
                    .Include(a => a.WildlifeSightings.OrderBy(w => w.Description).Where(w => !w.Description.Contains("Bear")))
                    .FirstOrDefault();
                OutPutWildlife(a_nobears);
            }
        }


        private static void SplitQueryInclude()
        {
            using (var context = new PeopleContext())
            {
                var address = context.Addresses.TagWith("No Split")
                    .Include(a => a.WildlifeSightings).FirstOrDefault();
                var address2 = context.Addresses.TagWith("Split Query")
                    .AsSplitQuery().Include(a => a.WildlifeSightings).FirstOrDefault();

            }
        }

        //private static void TPTWork()
        //{
        //    using (var context = new PeopleContext())
        //    {
        //        context.AddRange(
        //          new ScaryWildlifeSighting {
        //              AddressId = 1, DateTime = DateTime.Now, Description = "Bear",
        //              Experience = "OMG I almost peed my pants" },
        //          new ScaryWildlifeSighting {
        //              AddressId = 1, DateTime = DateTime.Now, Description = "Snake", 
        //              Experience = "I think I scared that poor snake" });
        //        context.SaveChanges();
        //        context.ChangeTracker.Clear();
        //        var sighting = context.WildlifeSightings.OfType<ScaryWildlifeSighting>()
        //                              .Where(s => s.Experience.Contains("peed")).ToList();
        //    }
        //}


        private static void OutPutWildlife(Address input)
        {
            Console.WriteLine(input.Street);
            foreach (var wildlife in input.WildlifeSightings)
            {
                Console.WriteLine($"   {wildlife.DateTime}: {wildlife.Description}");
            }
        }


    }
}
