using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0API.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth0API.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public HomeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        public IActionResult Index()
        {
            return Ok(new
            {
                Message = "Hello from a public endpoint! You don't need to be authenticated to see this."
            });
        }
        [HttpGet("GetEmployees")]
        [Authorize]
        public IActionResult Employees()
        {
            return Ok(this._employeeService.GetEmployees());
        }
        [HttpGet("GetEmployeesByCity/{city}")]
        [Authorize]
        public IActionResult EmployeesByCity(string city)
        {
            return Ok(this._employeeService.GetEmployeesByCity(city));
        }
    }
}