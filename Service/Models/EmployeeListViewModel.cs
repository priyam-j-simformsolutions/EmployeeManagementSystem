using EmployeeManagement.Data.EmployeeData.Entities.StoredProcedure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Models
{
    public class EmployeeListViewModel 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
        public int TotalCount { get; set; }
        public string DOB { get; set; }
        public string JoinDate { get; set; }
    }
}
