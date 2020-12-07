using KickerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KickerAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(KickerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {

                //return;
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            var userRole = new Role { Name = "User" };
            var adminRole = new Role { Name = "Admin" };
            context.Roles.AddRange(
              userRole, adminRole);
            context.SaveChanges();

            var user1 = new User { Role = adminRole, Username = "test", Password = "test", FirstName = "Test", LastName = "Test", Email = "test.test@thomasmore.be" };

            context.Users.Add(user1);
            context.SaveChanges();


            var team1 = new Team { Captain = user1, CompanyName = "Washington Solutions", Location = "Nijlen", TeamName = "Washington Solutions"};
            context.Teams.AddRange(team1);

            context.SaveChanges();
        }
    }
}
