using AutoMapper;
using Data.EmployeeData.Entities;
using Data.UnitOfWork;
using EmployeeManagement.Data.EmployeeData.Entities.StoredProcedure;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.Helper;
using EmployeeManagement.Service.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Get employee details by employee id.
        /// </summary>
        /// <param name="id">Employee id.</param>
        /// <returns>EmployeeViewModel</returns>
        public async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            EmployeeViewModel result = new EmployeeViewModel();

            var empDetails = await _unitOfWork.Employees.GetSingleByIdAsync(x => x.Id == id);
            List<Skill> skills = (await _unitOfWork.Skills.FindByAsync(x => x.IsActive == true)).ToList();
            if (empDetails != null)
            {
                int[] EmployeeSkills = (await _unitOfWork.EmployeeSkills.FindByAsync(x => x.IdEmployee == id)).Select(x => x.IdSkill).ToArray();
                var hobbies = (await _unitOfWork.EmployeeHobbies.FindByAsync(x => x.IdEmployee == id)).Select(x => x.IdHobby).ToArray();

                result = _mapper.Map<EmployeeViewModel>(empDetails);
                result.Skills = skills.Select(x => new SkillViewModel
                {
                    Id = x.Id,
                    Skill = x.Skill1,
                    IsChecked = EmployeeSkills.Contains(x.Id),
                }).ToList();
                result.Hobbies = hobbies;
            }
            else
            {
                result.Skills = skills.Select(x => new SkillViewModel
                {
                    Id = x.Id,
                    Skill = x.Skill1,
                    IsChecked = false,
                }).ToList();
            }

            return result;
        }

        /// <summary>
        /// Save/Persist Employee details.
        /// </summary>
        /// <param name="employee">New/Modified employee details.</param>
        /// <returns>Employee id.</returns>
        public async Task<int> SaveEmployee(EmployeeViewModel employee)
        {
            Employee employeeEntity = _mapper.Map<Employee>(employee);
            employeeEntity.Modified = DateTime.Now;

            //edit employee
            if (employee.Id > 0)
            {
                //save employee data
                await _unitOfWork.Employees.UpdateAsync(employeeEntity);

                //delete existing skills and hobbies.
                await _unitOfWork.EmployeeHobbies.DeleteByAsync(x => x.IdEmployee == employee.Id);
                await _unitOfWork.EmployeeSkills.DeleteByAsync(x => x.IdEmployee == employee.Id);
                await _unitOfWork.CompleteAsync();

            }
            else// add employee
            {
                employeeEntity.Created = DateTime.Now;

                //save employee data
                await _unitOfWork.Employees.AddAsync(employeeEntity);
                await _unitOfWork.CompleteAsync();

            }

            //add updated data of skills and hobbies.
            await UpdateHobbies(employeeEntity.Id, employee.Hobbies);
            await UpdateSkills(employeeEntity.Id, employee.Skills.Where(x => x.IsChecked).Select(x => x.Id).ToArray());

            return employeeEntity.Id;
        }

        /// <summary>
        /// Get list of employee.
        /// </summary>
        /// <param name="sortBy">sort direction of list.</param>
        /// <param name="pageSize">page size for list.</param>
        /// <param name="offset">offset.</param>
        /// <returns>filtered list of employee.</returns>
        public async Task<List<EmployeeListViewModel>> GetEmployeeList(string sortBy, int pageSize, int offset)
        {
            ICollection<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(SqlHelper.SqlInputParam("@sortBy", sortBy, SqlDbType.VarChar));
            parameters.Add(SqlHelper.SqlInputParam("@pageSize", pageSize, SqlDbType.Int));
            parameters.Add(SqlHelper.SqlInputParam("@offset", offset, SqlDbType.Int));

            var data = await _unitOfWork.Employees.ExecuteStoredProcedureListAsync<EmployeeListWithPageSort>("EXEC EmployeeListWithPageSort @sortBy, @pageSize, @offset", parameters.ToArray());
            List<EmployeeListViewModel> result = _mapper.Map<List<EmployeeListViewModel>>(data);

            if (!result.Any())
                result = new List<EmployeeListViewModel>();

            return result;
        }

        /// <summary>
        /// Delete empolyee by employee id.
        /// </summary>
        /// <param name="id">Employee id.</param>
        public async Task DeleteEmployee(int id)
        {
            Employee entity = (await _unitOfWork.Employees.FindByAsync(x => x.Id == id)).FirstOrDefault();
            if (entity != null)
            {
                await _unitOfWork.EmployeeHobbies.DeleteByAsync(x => x.IdEmployee == entity.Id);
                await _unitOfWork.EmployeeSkills.DeleteByAsync(x => x.IdEmployee == entity.Id);
                await _unitOfWork.Employees.DeleteAsync(entity);
                await _unitOfWork.CompleteAsync();
            }
        }


        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>List of roles</returns>
        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            var roles = await _unitOfWork.Roles.FindByAsync(x => x.IsActive == true);
            List<RoleViewModel> result = _mapper.Map<List<RoleViewModel>>(roles);

            if (!result.Any())
                result = new List<RoleViewModel>();

            return result;
        }

        /// <summary>
        /// Get all hobbies.
        /// </summary>
        /// <returns>List of hobbies</returns>
        public async Task<List<HobbyViewModel>> GetAllHobbies()
        {
            var hobbies = await _unitOfWork.Hobbies.FindByAsync(x => x.IsActive == true);
            List<HobbyViewModel> result = _mapper.Map<List<HobbyViewModel>>(hobbies);

            if (!result.Any())
                result = new List<HobbyViewModel>();

            return result;
        }


        #region private methods
        /// <summary>
        /// Update hobbies for employee
        /// </summary>
        /// <param name="employeeId">employee id</param>
        /// <param name="hobbies">list of hobby ids</param>
        private async Task UpdateHobbies(int employeeId, int[] hobbies)
        {
            IEnumerable<EmployeeHobby> newHobbies = hobbies.Select(hobbyId => new EmployeeHobby
            {
                IdEmployee = employeeId,
                IdHobby = hobbyId
            }).ToList();

            await _unitOfWork.EmployeeHobbies.UpdateHobbiesAsync(newHobbies);
            await _unitOfWork.CompleteAsync();
        }

        /// <summary>
        /// Update skills for employee
        /// </summary>
        /// <param name="employeeId">employee id</param>
        /// <param name="skills">list of skill ids</param>
        private async Task UpdateSkills(int employeeId, int[] skills)
        {
            IEnumerable<EmployeeSkill> newSkills = skills.Select(skillId => new EmployeeSkill
            {
                IdEmployee = employeeId,
                IdSkill = skillId
            }).ToList();

            await _unitOfWork.EmployeeSkills.UpdateSkillsAsync(newSkills);
            await _unitOfWork.CompleteAsync();
        }
        #endregion
    }
}
