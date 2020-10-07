using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0API.Application.DTO;
using Auth0API.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth0API.Controllers
{
    [Authorize("read:employees")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        /// <summary>
        /// This method is used to return a list of employees, authorization is required
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employee = this._employeeService.GetEmployees();
                if (employee == null) return NotFound();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// This method is used to return a list of employees filtered by city, authorization is required
        /// </summary>
        /// <param name="city">Name of the city to be used as filter</param>
        /// <returns></returns>
        [HttpGet("city/{city}")]
        public IActionResult GetByCity(string city)
        {
            try
            {
                var employee = this._employeeService.GetEmployeesByCity(city);
                if (employee == null) return NotFound(employee);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// This method is used to insert a new employee, authorization is required
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void Post([FromBody]EmployeeDTO employeeDTO)
        {
           _employeeService.AddNewEmployee(employeeDTO);
        }
    }
}