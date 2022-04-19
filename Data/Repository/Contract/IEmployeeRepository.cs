using Data.EmployeeData.Entities;
using EmployeeManagement.Data.EmployeeData.Entities.StoredProcedure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Contract
{
    public interface IEmployeeRepository: IRepositoryBase<Employee>
    {
    }
}
