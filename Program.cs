using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TMM_Asp.Models;
using TMM_Asp.Data;

namespace TMM_Asp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            using (var db = new DBModel())
            {
                // Create
                Console.WriteLine("Inserted New Team Member");
                db.Add(new MemberModel {
                    FirstName = "Dave",
                    LastName = "Manoa",
                    Address = "554 E 1150 N",
                    EmailAddress = "dave.manoa@gmail.com",
                    PhoneNumber = "801-222-3333",
                    Position = "Bossman",
                    Department = "The World",
                    StartDate = "Long time ago",
                    EndDate = "N/A",
                    EmploymentStatus = "active",
                    Shift = "24/7",
                    Manager = "God",
                    Photo = "None",
                    FavoriteColor = "Green"
                });
                db.SaveChanges();

                // Read
                Console.WriteLine("Read All Team Members");
                var blog = db.Members
                    .OrderBy(b => b.LastName)
                    .First();

                // Update
                //Console.WriteLine("Updating the blog and adding a post");
                //blog.EmailAddress = "https://devblogs.microsoft.com/dotnet";
                //blog.Add(
                //   );
                //db.SaveChanges();

                // Delete
                Console.WriteLine("Deleted Team Member");
                db.Remove(blog);
                db.SaveChanges();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
