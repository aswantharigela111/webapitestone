using Microsoft.AspNetCore.Mvc;
using testone.Models;

namespace testone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypeController : Controller
    {

        // Static list of employees to simulate a data source
        private static readonly List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Gender = "Male", City = "New York", Age = 30, Department = "HR" },
            new Employee { Id = 2, Name = "Jane Smith", Gender = "Female", City = "Los Angeles", Age = 25, Department = "Finance" },
            new Employee { Id = 3, Name = "Mike Johnson", Gender = "Male", City = "Chicago", Age = 40, Department = "IT" }
        };

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


        [HttpGet("Sample")]
        public string Index()
        {
            return "Primitive type";
        }

        [HttpGet("All")]
        public IEnumerable<Employee> GetAllEmployee()
        {
            return new List<Employee>()
            {
                new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
                new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
                new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
            };
        }

        /*
         IActionResult Return Type in ASP.NET Core Web API:

         In ASP.NET Core Web API, the IActionResult return type is an interface that allows the return of different types 
         of HTTP responses. It encapsulates the result of an HTTP request and can represent various HTTP status codes, 
         content types, and other response data. We will get the following Benefits from Using IActionResult.

          1.It allows actions to return different types of responses (e.g., different status codes and content types) 
          dynamically from a single action method. For example, an action can return Ok(), NotFound(), BadRequest(), or 
          any other HTTP response, depending on runtime conditions.
          2.You can control the exact response details, such as status codes, headers, and content.
         */

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                //In Real-Time, you will get the data from the database
                //Here, we have hardcoded the data
                var listEmployees = new List<Employee>()
                {
                    new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
                    //new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
                    //new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
                };
                if (listEmployees.Any())
                {
                    return Ok(listEmployees);
                }
                //return NotFound();
                return StatusCode(500, "List of employee is Zero");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Somting went wrong while processing your request");
            }
        }

        /*
         ActionResult<T> Return Type in ASP.NET Core Web API:

         ActionResult<T> is a return type in ASP.NET Core Web API that provides a way to return either an ActionResult or 
         a specific type T (either Complex or Primitive types) from controller actions. This allows us to take advantage 
         of both the flexible response modeling capabilities of IActionResult and the strong typing of specific data models
         .The following are the Benefits of Using ActionResult<T>:

          1.Type Safety: When you return T, you provide a strongly typed response, which can be beneficial for ensuring 
            data consistency and improving code readability and maintainability.
          2.Flexibility: ActionResult<T> combines the benefits of returning an IActionResult, which can represent various
            HTTP responses, with the ability also to return a type T directly. This means you can return standard HTTP 
            responses like NotFound() or BadRequest(), or you can return a specific data type when the operation is 
            successful.
         */
        [HttpGet("{Id:int}")]
        public ActionResult<Employee> GetEmpDetails(int Id)
        {
            try
            {
                var listEmployees = new List<Employee>()
                {
                    new Employee(){ Id = 1001, Name = "Anurag", Age = 28, City = "Mumbai", Gender = "Male", Department = "IT" },
                    new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, City = "Delhi", Gender = "Male", Department = "IT" },
                    new Employee(){ Id = 1003, Name = "Priyanka", Age = 27, City = "BBSR", Gender = "Female", Department = "HR"},
                };
                var empFound = listEmployees.FirstOrDefault(x => x.Id == Id);
                if (empFound != null)
                {
                    return Ok(empFound);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "While getting the using data somting went wrong");
            }
        }

        /*
         Task<IActionResult> or Task<ActionResult<T>> Return Type in ASP.NET Core:
        For asynchronous operations, we can use the Task<IActionResult> or Task<ActionResult<T>> return type. 
        This allows our action methods to perform asynchronous operations and return various responses.

        Task<IActionResult> Return Type in ASP.NET Core Web API:

        In ASP.NET Core Web API, the Task<IActionResult> return type is used to support asynchronous action methods. 
        This approach is commonly used when the action method performs asynchronous operations. It is a combination of 
        two concepts: Task<T> for asynchronous programming and IActionResult for flexible HTTP responses. This combination 
        is useful in scenarios where non-blocking I/O operations are required, such as when dealing with external web 
        services, databases, or file systems.

        1.Task<T>: This part of the return type specifies that the method is asynchronous. This is useful for I/O-bound operations where the thread can be freed up to handle other requests while waiting for the operation to complete. This is essential for scaling web applications, as it enables the server to serve more requests with fewer resources.
        2.IActionResult: The IActionResult interface allows the action method to return different types of responses from an API controller. For example, you can return successful results with data (Ok(object)) or HTTP status codes without data (NotFound(), BadRequest()), among others.
         */



        [HttpGet("GetAllEMp")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                // Simulate an asynchronous operation
                await Task.Delay(TimeSpan.FromSeconds(1));
                // Return the list of employees with a 200 OK status
                return Ok(Employees);
            }
            catch (Exception)
            {
                // Return 500 Internal Server Error in case of an exception
                return StatusCode(500, "Internal server error");
            }
        }
        // Read (GET employee by ID)
        [HttpGet("asny/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                // Simulate an asynchronous operation
                await Task.Delay(TimeSpan.FromSeconds(1));
                // Find the employee with the specified ID
                var employee = Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    // If the employee is not found, return a 404 Not Found status with a custom message
                    return NotFound(new { message = $"No employee found with ID {id}" });
                }
                // If the employee is found, return it with a 200 OK status
                return Ok(employee);
            }
            catch (Exception)
            {
                // Return 500 Internal Server Error in case of an exception
                return StatusCode(500, "Internal server error");
            }
        }
        // Create (POST new employee)
        [HttpPost()]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                // Simulate an asynchronous operation
                await Task.Delay(TimeSpan.FromSeconds(1));
                // Validate the employee data
                if (employee == null || string.IsNullOrEmpty(employee.Name))
                {
                    // If the data is invalid, return a 400 Bad Request status with a custom message
                    return BadRequest(new { Message = "Invalid employee data" });
                }
                // Assign a new ID to the employee
                employee.Id = Employees.Count + 1;
                // Add the employee to the list
                Employees.Add(employee);
                // Return a 201 Created status with a location header pointing to the newly created employee
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
            }
            catch (Exception)
            {
                // Return 500 Internal Server Error in case of an exception
                return StatusCode(500, "Internal server error");
            }
        }
        // Update (PUT existing employee)
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                // Simulate an asynchronous operation
                await Task.Delay(TimeSpan.FromSeconds(1));
                // Validate the employee data
                if (employee == null || id != employee.Id)
                {
                    // If the data is invalid, return a 400 Bad Request status with a custom message
                    return BadRequest(new { Message = "Invalid employee data" });
                }
                // Find the existing employee with the specified ID
                var existingEmployee = Employees.FirstOrDefault(e => e.Id == id);
                if (existingEmployee == null)
                {
                    // If the employee is not found, return a 404 Not Found status
                    return NotFound();
                }
                // Update the employee properties
                existingEmployee.Name = employee.Name;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.City = employee.City;
                existingEmployee.Age = employee.Age;
                existingEmployee.Department = employee.Department;
                // Return a 204 No Content status to indicate that the update was successful
                return NoContent();
            }
            catch (Exception)
            {
                // Return 500 Internal Server Error in case of an exception
                return StatusCode(500, "Internal server error");
            }
        }
        // Delete (DELETE employee)
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                // Simulate an asynchronous operation
                await Task.Delay(TimeSpan.FromSeconds(1));
                // Find the employee with the specified ID
                var employee = Employees.FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    // If the employee is not found, return a 404 Not Found status
                    return NotFound();
                }
                // Remove the employee from the list
                Employees.Remove(employee);
                // Return a 200 OK status with no content
                return Ok();
            }
            catch (Exception)
            {
                // Return 500 Internal Server Error in case of an exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
