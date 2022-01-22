using Microsoft.AspNetCore.Identity;
using Musik_Affär.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Musik_Affär.Data
{
    public class MockData
    {
        public static async Task Read(ApplicationDbContext database, UserManager<IdentityUser> userManager)
        {
            if (!database.Users.Any())
            {
                //Test account with username test@example.se and password !Testing00
                string testEmail = "test@example.se";
                var test = new IdentityUser(testEmail)
                {
                    Email = testEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(test, "!Testing00");
            }
            if (database.Products.Any())
            {
                return;
            }
            using var reader = new StreamReader("./Data/Musik-affar.csv");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(";");

                database.Products.Add(new Product
                {
                    Name = values[0],
                    Brand = values[1],
                    Category = values[2],
                    Color = values[3],
                    Price = decimal.Parse(values[4])
                });
            }
            await database.SaveChangesAsync();
        }
    }
}

