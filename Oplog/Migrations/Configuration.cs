using Oplog.Models;

namespace Oplog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Oplog.Models.OpLogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Oplog.Models.OpLogContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.OrganizationTypes.AddOrUpdate(x => x.Name,
                                                  new OrganizationType {Id = 1, Name = "Pirates"},
                                                  new OrganizationType {Id = 2, Name = "Marines"}
                );

            context.Organizations.AddOrUpdate(x => x.Name,
                                              new Organization { Id = 1, Name = "Straw Hat Pirates", OrgTypeId = 1 },
                                              new Organization { Id = 2, Name = "Donquixote Pirates", OrgTypeId = 1 }
                );
            context.Characters.AddOrUpdate(x => new{ x.Name ,x.OrganizationId},
                                           new Character { Id = 1, Name = "Monkey D. Luffy", OrganizationId = 1 },
                                           new Character { Id = 2, Name = "Roronoa Zoro", OrganizationId = 1 },
                                           new Character { Id = 3, Name = "Nami", OrganizationId = 1 },
                                           new Character { Id = 4, Name = "Usopp", OrganizationId = 1 },
                                           new Character { Id = 5, Name = "Sanji", OrganizationId = 1 },
                                           new Character { Id = 6, Name = "Tony Tony Chopper", OrganizationId = 1 },
                                           new Character { Id = 7, Name = "Nico Robin", OrganizationId = 1 },
                                           new Character { Id = 8, Name = "Franky", OrganizationId = 1 },
                                           new Character { Id = 9, Name = "Brook", OrganizationId = 1 },
                                           new Character { Id = 10, Name = "Donquixote Doflamingo", OrganizationId = 2 },
                                           new Character { Id = 11, Name = "Vergo", OrganizationId = 2 },
                                           new Character { Id = 12, Name = "Trebol", OrganizationId = 2 },
                                           new Character { Id = 13, Name = "Diamante", OrganizationId = 2 },
                                           new Character { Id = 14, Name = "Pica", OrganizationId = 2 },
                                           new Character { Id = 15, Name = "Sugar", OrganizationId = 2 },
                                           new Character { Id = 16, Name = "Monet", OrganizationId = 2 },
                                           new Character { Id = 17, Name = "Jora", OrganizationId = 2 },
                                           new Character { Id = 18, Name = "Violet", OrganizationId = 2 },
                                           new Character { Id = 19, Name = "Lao G", OrganizationId = 2 },
                                           new Character { Id = 20, Name = "Senor Pink", OrganizationId = 2 },
                                           new Character { Id = 21, Name = "Machvise", OrganizationId = 2 },
                                           new Character { Id = 22, Name = "Dellinger", OrganizationId = 2 },
                                           new Character { Id = 23, Name = "Gladius", OrganizationId = 2 },
                                           new Character { Id = 24, Name = "Buffalo", OrganizationId = 2 },
                                           new Character { Id = 25, Name = "Baby 5", OrganizationId = 2 },
                                           new Character { Id = 26, Name = "Caesar Clown", OrganizationId = 2 },
                                           new Character { Id = 27, Name = "Bellamy", OrganizationId = 2 }
                );
            context.Files.AddOrUpdate(x=>new {x.Id, x.CharacterId},
                    new File { Id = 1, Name = "luffy_icon.jpg" , Path="Images/", CharacterId = 1, IsDefault = true}
                
                );


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
