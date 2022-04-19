using Data.EmployeeData.Context;
using Data.EmployeeData.Entities;
using Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Implementation
{
    public class HobbyRepository : RepositoryBase<Hobby>, IHobbyRepository
    {
        public HobbyRepository(EmployeeManagementContext context) : base(context)
        {

        }
    }
}
