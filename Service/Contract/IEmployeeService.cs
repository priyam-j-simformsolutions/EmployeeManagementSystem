using EmployeeManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Contract
{
    public interface IEmployeeService
    {
        Task<EmployeeViewModel> GetEmployeeById(int id);
        Task<int> SaveEmployee(EmployeeViewModel employee);
        Task<List<EmployeeListViewModel>> GetEmployeeList(string sortBy, int pageSize, int offset);
        Task DeleteEmployee(int id);
        Task<List<RoleViewModel>> GetAllRoles();
        Task<List<HobbyViewModel>> GetAllHobbies();

    }
}
