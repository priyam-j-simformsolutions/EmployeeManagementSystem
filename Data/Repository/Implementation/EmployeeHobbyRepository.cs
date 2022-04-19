using Data.EmployeeData.Context;
using Data.EmployeeData.Entities;
using Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class EmployeeHobbyRepository : RepositoryBase<EmployeeHobby>, IEmployeeHobbyRepository
    {
        public EmployeeHobbyRepository(EmployeeManagementContext context) : base(context)
        {
            this._context = context;
        }
        private EmployeeManagementContext _context { get; }

        public async Task UpdateHobbiesAsync(IEnumerable<EmployeeHobby> hobbies)
        {
            await this._context.Set<EmployeeHobby>().AddRangeAsync(hobbies);
        }
    }
}
