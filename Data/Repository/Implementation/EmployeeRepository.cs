using Data.EmployeeData.Context;
using Data.EmployeeData.Entities;
using Data.Repository.Contract;
using EmployeeManagement.Data.EmployeeData.Entities.StoredProcedure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementContext context) : base(context)
        {
        }
    }
}
