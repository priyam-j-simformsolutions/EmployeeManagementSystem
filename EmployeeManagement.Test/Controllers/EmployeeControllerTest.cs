using EmployeeManagement.Controllers;
using EmployeeManagement.Service.Contract;
using EmployeeManagement.Service.Models;
using JqueryDataTables.ServerSide.AspNetCoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test.Controllers
{
    public class EmployeeControllerTest
    {
        [Fact]
        public void EmployeeList_ReturnsJsonResult_WithAListOfEmployees()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(repo => repo.GetEmployeeList(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(GetTestEmployees());
            var controller = new EmployeeController(mockEmployeeService.Object);
            // Act
            var result = controller.EmployeeList(new JqueryDataTablesParameters()).Result;
            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Edit_ReturnsViewResult_WithAEmployeeDetails(int id)
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(repo => repo.GetEmployeeById(id))
                .Returns(GetTestEmployee(id));
            mockEmployeeService.Setup(repo => repo.GetAllHobbies())
               .Returns(GetHobbies());
            mockEmployeeService.Setup(repo => repo.GetAllRoles())
               .Returns(GetRoles());
            var controller = new EmployeeController(mockEmployeeService.Object);
            // Act
            var result = controller.Edit(id).Result;
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var roles = Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["roles"]);
            var hobbies = Assert.IsAssignableFrom<SelectList>(viewResult.ViewData["hobbies"]);
            Assert.NotNull(result);
        }


        [Fact]
        public void Edit_ReturnsViewResult_WithRedirctIndexResult()
        {
            // Arrange
            var model = GetEmployeeValidRequest();
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(repo => repo.SaveEmployee(model))
                .Returns(Task.FromResult(model.Id));

            var controller = new EmployeeController(mockEmployeeService.Object);

            // Act
            var result = controller.Edit(model).Result;
            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("employee", viewResult.ControllerName.ToLower());
            Assert.Equal("index", viewResult.ActionName.ToLower());
            Assert.NotNull(result);
        }

        [Fact]
        public void Edit_ReturnsViewResult_WithValidateMessage()
        {
            // Arrange
            var model = GetEmployeeBadRequest();
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(repo => repo.SaveEmployee(model))
                .Returns(Task.FromResult(model.Id));
           
            var controller = new EmployeeController(mockEmployeeService.Object);
            controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var result = controller.Edit(model).Result;
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<EmployeeViewModel>(badRequestResult.Value);

        }




        private async Task<List<EmployeeListViewModel>> GetTestEmployees()
        {
            return new List<EmployeeListViewModel>(){
                new EmployeeListViewModel()
                {
                    Id = 1,
                    FirstName = "Priyam"
                },
                new EmployeeListViewModel()
                {
                    Id = 2,
                    FirstName = "Jasoliya"
                }
            };
        }

        private async Task<EmployeeViewModel> GetTestEmployee(int id)
        {
            return new EmployeeViewModel()
            {
                Id = id,
                FirstName = "Priyam"
            };
        }
        private async Task<List<RoleViewModel>> GetRoles()
        {
            return new List<RoleViewModel>(){
                new RoleViewModel()
                {
                    Id = 1,
                    Role = "Software Developer"
                },
                new RoleViewModel()
                {
                    Id = 2,
                    Role = "Project Manager"
                }
            };
        } 
        
        private async Task<List<HobbyViewModel>> GetHobbies()
        {
            return new List<HobbyViewModel>(){
                new HobbyViewModel()
                {
                    Id = 1,
                    Hobby = "Reading"
                },
                new HobbyViewModel()
                {
                    Id = 2,
                    Hobby = "Photography"
                }
            };
        }


        private  EmployeeViewModel GetEmployeeBadRequest()
        {
            return new EmployeeViewModel()
            {
                Id = 1,
                FirstName = "Priyam"
            };
        }

        private EmployeeViewModel GetEmployeeValidRequest()
        {
            return new EmployeeViewModel()
            {
                Id = 1,
                FirstName = "Priyam",
                LastName = "Jasoliya",
                Dob = System.DateTime.Now,
                JoiningDate = System.DateTime.Now,
                About = "I am a Software developer",
                Address = "Ahmedabad, Gujarat, India",
                Gender = "Male",
                Hobbies = new int[] { 1, 2, 3 },
                Role =  3,
            };
        }
    }
}
