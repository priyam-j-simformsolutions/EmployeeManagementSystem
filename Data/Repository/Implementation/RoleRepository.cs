using Data.EmployeeData.Context;
using Data.EmployeeData.Entities;
using Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Implementation
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(EmployeeManagementContext context) : base(context)
        {
        }
    }
}
