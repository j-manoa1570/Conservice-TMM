using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMM_Asp.Models
{
    public class MemberModel
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmploymentStatus { get; set; }
        public string Shift { get; set; }
        public string Manager { get; set; }
        public string Photo { get; set; }
        public string FavoriteColor { get; set; }
    }
}
