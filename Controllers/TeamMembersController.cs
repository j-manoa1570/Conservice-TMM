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
        public IActionResult FilterTeam(List<string> filters)
        {
            var employees = BuildTestRecords();
            var team = GetFilteredList(employees, filters);

            return View(team);

        }


        // GET: TeamMembers/Search
        public IActionResult Search(List<string> names)
        {
            var employees = BuildTestRecords();
            var team = BuildSearchList(employees, names);


            return View(team);
        }

        public IActionResult Delete(List<string> employee)
        {
            // TODO: SQL Remove from database
            // foreach (var id in employee)
            //    Remove from database user with id
            var employees = BuildTestRecords();
            var team = MakeTeam(employees);
            return View(team);
        }


        // Build Search List
        private TeamMembersModel BuildSearchList(List<MemberModel> employees, List<string> names)
        {
            var members = new List<MemberModel>();
            foreach (var employee in employees)
            {
                foreach (var name in names)
                {
                    if (employee.FirstName == name)
                        members.Add(employee);
                    else if (employee.LastName == name)
                        members.Add(employee);
                }
            }

            return MakeTeam(members);
        }
        // Get Filtered List
        private TeamMembersModel GetFilteredList(List<MemberModel> employees, List<string> filters)
        {
            var members = new List<MemberModel>();

            foreach (var employee in employees)
            {
                foreach (var filter in filters)
                {    if (employee.Department == filter)
                        members.Add(employee);
                    else if (employee.EmploymentStatus == filter)
                        members.Add(employee);
                    else if (employee.Position == filter)
                        members.Add(employee);
                    else if (employee.Shift == filter)
                        members.Add(employee);
                    else if (employee.Manager == filter)
                        members.Add(employee);
                }
            }

            return MakeTeam(members);
        }
        // Build test records.
        List<MemberModel> BuildTestRecords ()
        {
            var employees = new List<MemberModel>
            {
                new MemberModel{
                    FirstName = "Jack",
                    LastName = "Black",
                    Address = "1612 Guitar Road",
                    EmailAddress = "jack.black@gmail.com",
                    PhoneNumber = "801-222-3333",
                    Position = "Bossman",
                    Department = "The World",
                    StartDate = "Long time ago",
                    EndDate = "N/A",
                    EmploymentStatus = "active",
                    Shift = "24/7",
                    Manager = "Himself",
                    Photo = "None",
                    FavoriteColor = "Green"
                },

            new MemberModel {
                FirstName = "Jonathan",
                LastName = "Manoa",
                Address = "123 Unknown Drive",
                EmailAddress = "j.manoa1570@gmail.com",
                PhoneNumber = "805-345-5168",
                Position = "Bossman",
                Department = "The World",
                StartDate = "1 Jan 1900",
                EndDate = "N/A",
                EmploymentStatus = "active",
                Shift = "24/7",
                Manager = "Me",
                Photo = "None",
                FavoriteColor = "Blue"
            },

            new MemberModel {
                FirstName = "The",
                LastName = "Rock",
                Address = "1000 Cookin Lane",
                EmailAddress = "the.rock@gmail.com",
                PhoneNumber = "none",
                Position = "The People's Elbow'",
                Department = "The Gym",
                StartDate = "Many years ago",
                EndDate = "N/A",
                EmploymentStatus = "active",
                Shift = "24/7 for one whole year",
                Manager = "He is his own",
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