using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMM_Asp.Models;

namespace TMM_Asp.Controllers
{
    public class TeamMembersController : Controller
    {
        // GET: TeamMembers/Member
        public IActionResult Member(string SortMethod)
        {
            var employees = BuildTestRecords();


            /*
             * Sort Method
             */
            if (SortMethod == "FirstName")
                employees.Sort((x, y) => x.FirstName.CompareTo(y.FirstName));
            else if (SortMethod == "FavoriteColor")
                employees.Sort((x, y) => x.FavoriteColor.CompareTo(y.FavoriteColor));
            else if (SortMethod == "Address")
                employees.Sort((x, y) => x.Address.CompareTo(y.Address));
            else if (SortMethod == "EmailAddress")
                employees.Sort((x, y) => x.EmailAddress.CompareTo(y.EmailAddress));
            else if (SortMethod == "Department")
                employees.Sort((x, y) => x.Department.CompareTo(y.Department));
            else if (SortMethod == "Manager")
                employees.Sort((x, y) => x.Manager.CompareTo(y.Manager));
            else if (SortMethod == "Shift")
                employees.Sort((x, y) => x.Shift.CompareTo(y.Shift));
            else if (SortMethod == "StartDate")
                employees.Sort((x, y) => x.StartDate.CompareTo(y.StartDate));
            else if (SortMethod =="EndDate")
                employees.Sort((x, y) => x.EndDate.CompareTo(y.EndDate));
            else if (SortMethod == "EmploymentStatus")
                employees.Sort((x, y) => x.EmploymentStatus.CompareTo(y.EmploymentStatus));
            else if (SortMethod == "Photo")
                employees.Sort((x, y) => x.Photo.CompareTo(y.Photo));
            else if (SortMethod == "PhoneNumber")
                employees.Sort((x, y) => x.PhoneNumber.CompareTo(y.PhoneNumber));
            else if (SortMethod == "Position")
                employees.Sort((x, y) => x.Position.CompareTo(y.Position));
            else
                employees.Sort((x, y) => x.LastName.CompareTo(y.LastName));

            var team = MakeTeam(employees);

            return View(team);
        }

        // GET: TeamMembers/FilterTeam
        public IActionResult FilterTeam()
        {
            var employees = BuildTestRecords();
            var team = MakeTeam(employees);

            return View(team);

        }


        // GET: TeamMembers/Search
        public IActionResult Search()
        {
            var employees = BuildTestRecords();
            var team = MakeTeam(employees);

            return View(team);
        }


        // Build test records.
        List<MemberModel> BuildTestRecords ()
        {
            var employees = new List<MemberModel>
            {
                new MemberModel{
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

            new MemberModel {
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

            new MemberModel {
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

            return employees;
        }
        // Builds the team object that will be passed to the view.
        TeamMembersModel MakeTeam (List<MemberModel> employees)
        {

            var employment = new Dictionary<string, int>();
            var position = new Dictionary<string, int>();
            var shift = new Dictionary<string, int>();
            var department = new Dictionary<string, int>();
            var manager = new Dictionary<string, int>();

            // Pull data from the records that have come in.
            // Foreach is pulling all of the filter options.
            foreach (var employee in employees)
            {
                if (employment.ContainsKey(employee.EmploymentStatus))
                {
                    employment[employee.EmploymentStatus] += 1;
                }
                else
                {
                    employment.Add(employee.EmploymentStatus, 1);
                }

                if (position.ContainsKey(employee.Position))
                {
                    position[employee.Position] += 1;
                }
                else
                {
                    position.Add(employee.Position, 1);
                }

                if (shift.ContainsKey(employee.Shift))
                {
                    shift[employee.Shift] += 1;
                }
                else
                {
                    shift.Add(employee.Shift, 1);
                }

                if (department.ContainsKey(employee.Department))
                {
                    department[employee.Department] += 1;
                }
                else
                {
                    department.Add(employee.Department, 1);
                }

                if (manager.ContainsKey(employee.Manager))
                {
                    manager[employee.Manager] += 1;
                }
                else
                {
                    manager.Add(employee.Manager, 1);
                }
            }

            var team = new TeamMembersModel()
            {
                Employees = employees,
                Employment = employment,
                Position = position,
                Shift = shift,
                Department = department,
                Manager = manager
            };

            return team;
        }
    } 
}