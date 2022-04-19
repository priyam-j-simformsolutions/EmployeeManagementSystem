using Data.EmployeeData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Contract
{
    public interface IEmployeeHobbyRepository : IRepositoryBase<EmployeeHobby>
    {
        Task UpdateHobbiesAsync(IEnumerable<EmployeeHobby> hobbies);
    }
}
