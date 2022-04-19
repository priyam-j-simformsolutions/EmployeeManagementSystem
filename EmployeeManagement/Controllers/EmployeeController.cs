using AutoMapper;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Employee Index page.
        /// </summary>
        /// <returns>Index view.</returns>
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Employeelist based on datatable filter params.
        /// </summary>
        /// <param name="param">datatable filter params.</param>
        /// <returns>Filtered employeelist data in Json.</returns>
        [HttpPost]
        public async Task<IActionResult> EmployeeList([FromForm] JqueryDataTablesParameters param)
        {
            List<EmployeeListViewModel> results = await _employeeService.GetEmployeeList(param.SortOrder, param.Length, param.Start);

            int totalSize = results.FirstOrDefault()?.TotalCount ?? 0;
            return new JsonResult(new JqueryDataTablesResult<EmployeeListViewModel>
            {
                Draw = param.Draw,
                Data = results,
                RecordsFiltered = totalSize,
                RecordsTotal = totalSize
            });
        }


        /// <summary>
        /// Get Employee details by employee id.
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns>Employee details view.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var roles = await _employeeService.GetAllRoles();
            var hobbies = await _employeeService.GetAllHobbies();
            ViewBag.Roles = new SelectList(roles, "Id", "Role");
            ViewBag.Hobbies = new SelectList(hobbies, "Id", "Hobby");

            EmployeeViewModel employeeViewModel = await _employeeService.GetEmployeeById(id ?? 0);

            return View(employeeViewModel);
        }


        /// <summary>
        /// Save New/Modified employee details.
        /// </summary>
        /// <param name="model">Employee details model</param>
        /// <returns>redirects to employee index.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.SaveEmployee(model);
                return RedirectToAction("Index", "Employee");
            }

            return BadRequest(model);
        }

        /// <summary>
        /// Delete employee by employeeId.
        /// </summary>
        /// <param name="id">eEmployee Id</param>
        /// <returns>redirects to employee index.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
