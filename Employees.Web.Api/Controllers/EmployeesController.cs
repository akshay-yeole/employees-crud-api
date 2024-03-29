﻿using EMS.Core.Models;
using EMS.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllEmployees()
        {
            var res = await _employeeService.GetAllEmployees();
            return Ok(res);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Employee), 201)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            await _employeeService.AddEmployee(employee);
            return Ok();
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetEmployeeById([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateEmployeeById([FromRoute] Guid id, Employee employeeUpdateRequestModel )
        {
           await _employeeService.UpdateEmployeeById(id,employeeUpdateRequestModel);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id )
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }
    }
}
