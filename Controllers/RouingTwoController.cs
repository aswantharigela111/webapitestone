using Microsoft.AspNetCore.Mvc;

namespace testone.Controllers
{
    

    [ApiController]
    //Token Repalcement in Routing 
    // [Route("[controller]/[action]")]

    [Route("ControllerName")]
    public class RouingTwoController : Controller
    {

        [HttpGet("all")]
        public string tokenReplacement()
        {
            return "Hello";
        }


        [HttpGet("{DeparmentId}")]
        public string GetQueryValPrefix(int DeparmentId)
        {
            return $"Getting Query value using :{DeparmentId}";
        }


        //Overriding the controller name
        [HttpGet("~/department/all")]
        public string GetAllDepartment()
        {
            return "Response from GetAllDepartment Method";
        }

        //[HttpGet]
        //[Route("{Id}")]
        //public string GetQueryVal(int Id)
        //{
        //    return $"Getting Query value using :{Id}";
        //}

        /*
         ASP.NET Core Web API Attribute Routing with Route Constraints
         Route constraints in ASP.NET Core Web API are used to restrict the HTTP requests that can match a particular route. 
         They enable the API to ensure that the parameters of a route are of a certain type, range, or pattern, which can be essential for the API’s logic and security. 
         Implementing route constraints effectively can lead to more robust and error-free applications.

        The Route Constraints in ASP.NET Core Web API Attribute Routing are nothing but a set of rules that can be applied to routing parameters to restrict how the 
        parameters in the route template are matched. The syntax to use Route Constraints is: {parameter:constraint}
         */

        //[Route("{EmployeeName:alpha:minlength(5):maxlength(10)}")]
        //[HttpGet]
        //public string GetEmployeeDetails(string EmployeeName)
        //{
        //    return $"Response from GetEmployeeDetails Method, EmployeeName : {EmployeeName}";
        //}

        //[Route("{EmployeeName:alpha:length(5)}")]
        //[HttpGet]
        //public string GetEmployeeDetails2(string EmployeeName)
        //{
        //    return $"Response from GetEmployeeDetails Method, EmployeeName : {EmployeeName}";
        //}

        //[Route("{EmployeeName:regex(a(b|c))}")]
        //[HttpGet]
        //public string GetEmployeeDetails3(string EmployeeName)
        //{
        //    return $"Response from GetEmployeeDetails Method, EmployeeName : {EmployeeName}";
        //}

        //[HttpGet("{EmployeeId:int}")]
        //public string GetEmployeeDetails4(int EmployeeId)
        //{
        //    return $"Response from GetEmployeeDetails Method, EmployeeId : {EmployeeId}";
        //}

        /*Advantages of Using Route Constraints in ASP.NET Core Web API
            Validation at Routing Level: Route constraints validate requests before they reach the action method, potentially reducing unnecessary processing for invalid requests.

            Improved Security: By ensuring that only requests with appropriately formatted parameters are processed, route constraints can help mitigate certain types of attacks.

            Improved URL Matching: By defining precise criteria for route parameters, constraints help ensure that URLs are routed to the appropriate actions.
         */
    }

}
