# Employee Management System

Employee Management System is a System to manage Employee for an organization. it has functionality to Create employee, Update Employee and delete employee. Employee can have details like Name, Address, Roles, Skills and Hobbies.

# Getting Started
### Prerequisites  
 - Visual Studio 2019 or later  
 - .Net Core (3.1)

### Dependancies
#### Nuget Packages
- Microsoft.AspNetCore.Mvc.NewtonsoftJson 
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- JqueryDataTables.ServerSide.AspNetCoreWeb
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- xunit
- xunit.runner.visualstudio
- Moq

### Database
Database Server: SQL Server 2019
Database Name: EmployeeManagement

### Project Architecture

 - EmployeeManagement.Data (Conatins database model and repositories of all the entities)
 - EmployeeManagement.Services(Contains business logic)
 - EmployeeManagement(Web)  
 - EmployeeManagement.Test(Contains all the test methods)

## Running the tests
In this project we have used XUnit.
You can run all the tests from the Test Explorer. If Test Explorer is not visible, choose  **Test**  on the Visual Studio menu, choose  **Windows**, and then choose  **Test Explorer**. All the unit tests will be listed so choose the test you want to run. You can also run alto tests by selecteing "Run All" option.

