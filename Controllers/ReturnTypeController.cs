using Microsoft.AspNetCore.Mvc;

namespace testone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypeController : Controller
    {
        /*
         Controller Action Return Types in ASP.NET Core Web API
            In ASP.NET Core Web API, controller actions can return various types of responses depending on the specific 
            requirements of each endpoint to handle different scenarios and provide flexibility in how responses are sent 
            to clients. So, these return types help manage the HTTP response sent back to the client. In ASP.NET Core Web API,
            we can return data from the controller action method in many different ways. They are as follows:

            1.Primitive or Complex Types
            2.IActionResult
            3.ActionResult<T>
            4.Specific Result Types
            5.Task<IActionResult> or Task<ActionResult<T>>
         */


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
