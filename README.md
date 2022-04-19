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

## Deployment
### Deployement server
If you have multiple server for the stage and production then specify all the details here

### Deployement prerequistes
If you have EC2 instance or any VPS server then install below prerequistes software in the machine
1. Install IIS
2. Install .Net Framework

### Deployement Steps 
1. Create virtual directory under IIS
2. Enable Inbound and Outbound port for SQL Server(1433) in Firewall(If required)
3. Create security group in your production and stage server if you are using EC2 
4. Update the Database Connection string with Production in web.config
5. Publish your project         
6. Move your publish files to the stage/production server

## License

This project is licensed under the Simform Solutions Pvt. Ltd