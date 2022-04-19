using Data.EmployeeData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Contract
{
    public interface ILogService
    {
        Task SaveLog(ExceptionLogger exception);
    }
}
