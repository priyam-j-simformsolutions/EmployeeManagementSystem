using Data.EmployeeData.Context;
using Data.EmployeeData.Entities;
using Data.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Implementation
{
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        public SkillRepository(EmployeeManagementContext context) : base(context)
        {

        }
    }
}
