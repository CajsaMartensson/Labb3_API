using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<InterestPerson> InterestPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Anna Andersson", PhoneNumber = "0701234567" },
                     new Person { Id = 2, Name = "Björn Berg", PhoneNumber = "0739876543" },
                     new Person { Id = 3, Name = "Cecilia Ceder", PhoneNumber = "0700112233" },
                     new Person { Id = 4, Name = "Daniel Duva", PhoneNumber = "0763425138" },
                     new Person { Id = 5, Name = "Erik Ek", PhoneNumber = "0765554433" }
                );


            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Programmering", Description = "Konsten att bygga logik med C# och .NET." },
                     new Interest { Id = 2, Title = "Skidåkning", Description = "Allt från snabba pister till pudersnö i Alperna." },
                     new Interest { Id = 3, Title = "Matlagning", Description = "Experimenterande i köket med smaker från hela världen." },
                     new Interest { Id = 4, Title = "Hundsport", Description = "Träning och tävling inom agility, lydnad och sök." },
                     new Interest { Id = 5, Title = "Fotografering", Description = "Konsten att fånga ljus och ögonblick med digital systemkamera." },
                     new Interest { Id = 6, Title = "Brädspel", Description = "Strategiska sällskapsspel, från enkla klassiker till tunga Euro-games." },
                     new Interest { Id = 7, Title = "Träning", Description = "Allt från styrkelyft på gymmet till löpning i skogen." }
                );

            modelBuilder.Entity<InterestPerson>().HasData(
                 new InterestPerson { Id = 1, PersonId = 1, InterestId = 1 }, // Anna - Programmering
                    new InterestPerson { Id = 2, PersonId = 1, InterestId = 2 }, // Anna - Skidåkning
                    new InterestPerson { Id = 3, PersonId = 2, InterestId = 1 }, // Björn - Programmering
                    new InterestPerson { Id = 4, PersonId = 2, InterestId = 3 }, // Björn - Matlagning
                    new InterestPerson { Id = 5, PersonId = 3, InterestId = 1 }, // Cecilia - Programmering
                    new InterestPerson { Id = 6, PersonId = 3, InterestId = 5 }, // Cecilia - Fotografering
                    new InterestPerson { Id = 7, PersonId = 3, InterestId = 7 }, // Cecilia - Träning
                    new InterestPerson { Id = 8, PersonId = 4, InterestId = 4 }, // Daniel - Hundsport
                    new InterestPerson { Id = 9, PersonId = 4, InterestId = 6 }, // Daniel - Brädspel
                    new InterestPerson { Id = 10, PersonId = 5, InterestId = 1 }, // Erik - Programmering
                    new InterestPerson { Id = 11, PersonId = 5, InterestId = 7 }  // Erik - Träning
    );

            modelBuilder.Entity<Link>().HasData(
         // Anna (Länkar kopplade till hennes specifika intressen)
         new Link { Id = 1, Url = "https://learn.microsoft.com/dotnet", InterestPersonId = 1 },
         new Link { Id = 2, Url = "https://www.skistar.com", InterestPersonId = 2 },

         // Björn
         new Link { Id = 3, Url = "https://stackoverflow.com", InterestPersonId = 3 },
         new Link { Id = 4, Url = "https://www.tasteline.com", InterestPersonId = 4 },

         // Cecilia
         new Link { Id = 5, Url = "https://www.github.com", InterestPersonId = 5 },
         new Link { Id = 6, Url = "https://www.dpreview.com", InterestPersonId = 6 },
         new Link { Id = 7, Url = "https://www.styrkelabbet.se", InterestPersonId = 7 },

         // Daniel
         new Link { Id = 8, Url = "https://www.skk.se", InterestPersonId = 8 },
         new Link { Id = 9, Url = "https://boardgamegeek.com", InterestPersonId = 9 },

         // Erik
         new Link { Id = 10, Url = "https://www.codewars.com", InterestPersonId = 10 },
         new Link { Id = 11, Url = "https://www.runnersworld.se", InterestPersonId = 11 }
     );
        }
    }
}
