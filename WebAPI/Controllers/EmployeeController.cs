using ApplicationLayer.Contracts;
using ApplicationLayer.Queries.EmployeeQuery;
using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        private readonly IMediator mediator;

        public EmployeeController(IEmployee employee, IMediator mediator)
        {
            this.employee = employee;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await mediator.Send(new GetEmployeeListQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await mediator.Send(new GetEmployeeByIdQuery { Id = id }));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employeeDto)
        {
            var result = await employee.AddAsync(employeeDto); 
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employeeDto)
        {
            var result = await employee.UpdateAsync(employeeDto);
            return Ok(result);  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await employee.DeleteAsync(id);
            return Ok(result);  
        }
    }
}
