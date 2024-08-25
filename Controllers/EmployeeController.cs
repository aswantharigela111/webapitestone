using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testone.Models;
using static System.Net.WebRequestMethods;

namespace testone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //In this we are learing routing
        //Adding Attribute Routing in ASP.NET Core Web API 
        [Route("Emp/All")]
        [HttpGet]
        public string GetAllEmp()
        {
            return "By using the emp/all we can access the GetAllEmp method";
        }
        [Route("Emp/ByID/{Id}")]
        [HttpGet]
        public string GetEmpID(int Id)
        {
            return $"Get by Id is:{Id} ";
        }
        /*How is the Incoming Request Mapped to Controller Actions?
          Let us understand how the incoming HTTP Request is Mapped to Controller actions.
          This is possible because of the MapControllers Middleware, which we configured into the Request 
          processing pipeline within the Program class.
           app.MapControllers();*/


        [HttpGet]
        [Route("Emp/empname{name}/empid{id}")]
        public string GetRouteQueryValues(string name,int id)
        {
            return $"the first val:{name} and{id}";
        }

        /*
         How do you pass Multiple Query Strings in ASP.NET Core Web API?

         Let’s understand how to pass multiple query strings with an example. When we implement search functionality in
         a real-time application, we generally accept multiple search parameters to filter out the data.

        Let’s say we want to filter employees by city, gender, and department. In that case, our action method 
        accepts three parameters. So, modify the SearchEmployees method of the Employee Controller class as shown below. 
        If you want to make any query string parameter optional, then you need to use ? or initialize the parameter with 
        some default value.
         */

        [HttpGet]
        [Route ("Emp/Search")]
        //public string SrarchEmployee(string? Department,string? Gender,string? City)
        //{
        //    return $"Department:{Department} Gender:{Gender} City:{City}";
        //}

        public string SearchEmployees([FromQuery] EmployeeSearch employeeSearch)
        {
            return $"Return Employees with Department : {employeeSearch.Department}, Gender : {employeeSearch.Gender}, City : {employeeSearch.City}";
        }



        /*
         How to Access a Single Resource with Multiple URLs in ASP.NET Core Web API:
         In ASP.NET Core Web API, we can set up multiple URLs for a single resource using Attribute Routing. 
         Attribute routing allows us to define routes directly on controllers and actions, providing more flexibility in 
         defining the API’s URL structure.  Let us understand how to access a single resource with Multiple URLs with an 
          example. Suppose we have the following resource available in our Employee Controller.
         */
        [HttpGet]
        [Route("Employee/AllEmp")]
        [Route("AllEmployeesUsingMultiURL")]
        [Route("All")]
        public string GetAllEmployeeMulti()
        {
            return "Multiple URLS getting accsing the resource";
        }

        /*  NOTE
         Note: You need to remember that each resource must have a unique URL. It is possible to access a resource using multiple URLs as 
        long as all the URLs are unique. However, accessing two or more resources using a single URL in the ASP.NET Core Web API Application is impossible.
         */

    }
}
