using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Data.EmployeeData.Entities.StoredProcedure
{
    public class EmployeeListWithPageSort
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public string Skills { get; set; }
        public int TotalCount { get; set; }
    }
}
