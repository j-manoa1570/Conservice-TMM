using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMM_Asp.Models;
using TMM_Asp.Data;

namespace TMM_Asp.Data
{
    public class DbInitializer
    {
        public static void Initialize(DBModel context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var employees = new List<MemberModel>
            {
                new MemberModel
                {
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
                },

                new MemberModel
                {
                    FirstName = "Jonathan",
                    LastName = "Manoa",
                    Address = "738 Patterson Road",
                    EmailAddress = "j.manoa1570@gmail.com",
                    PhoneNumber = "805-345-5168",
                    Position = "Bossman",
                    Department = "The World",
                    StartDate = "22 May 1987",
                    EndDate = "N/A",
                    EmploymentStatus = "active",
                    Shift = "24/7",
                    Manager = "God",
                    Photo = "None",
                    FavoriteColor = "Blue"
                },

                new MemberModel
                {
                    FirstName = "Adin",
                    LastName = "Manoa",
                    Address = "554 E 1150 N",
                    EmailAddress = "adin.manoa@gmail.com",
                    PhoneNumber = "none",
                    Position = "12 yr old",
                    Department = "Jr High",
                    StartDate = "July 2007",
                    EndDate = "N/A",
                    EmploymentStatus = "active",
                    Shift = "24/7 for one whole year",
                    Manager = "Parents",
                    Photo = "None",
                    FavoriteColor = "Clear"
                }
            };

            foreach (var employee in employees)
            {
                context.Members.Add(employee);
            }
            context.SaveChanges();
        }
    }
}
