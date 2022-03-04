using AutoMapper;
using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.DTOs.EmployeeDto;
using EmployeeManagmentSystem.Models;
using EmployeeManagmentSystem.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        [SwaggerOperation(Summary = " İşçilərin siyahısının əldə edilməsi")]

        [HttpGet("getall")]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetEmployees();
                var data = _mapper.Map<IList<EmployeeToReturnDto>>(employees);
                return Ok(data);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong");
            }

        }

        [SwaggerOperation(Summary = "İşçilərin filter edilə bilməsi və səhifələnməsi")]
        [HttpGet("filterandpage")]
        public async Task<ActionResult> GetFilteredAndPagingEmployees([FromQuery] Paginator paginator, [FromQuery] string departmentname = null)
        {
            try
            {
                var employees = await _employeeRepository.GetFilteredAndPagingEmployees(paginator, departmentname);
                var data = _mapper.Map<IList<EmployeeToReturnDto>>(employees);
                return Ok(data);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Something went wrong");
            }

        }

        [SwaggerOperation(Summary = "İşçi məlumatlarına detallı baxmaq")]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById([FromRoute] int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                      "Something went wrong");
            }


        }

        [SwaggerOperation(Summary = "Yeni işçinin əlavə edilməsi")]
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] EmployeeAddDto model)
        {
            var employee = _mapper.Map<EmployeeAddDto, Employee>(model);
            try
            {
                if (employee == null) { return BadRequest(); }
                var newEmployee = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById),
                    new { id = newEmployee.Id }, newEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error creating new employee record");
            }

        }

        [SwaggerOperation(Summary = "İşçinin silinməsi")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
        {
            try
            {

                var employeeToDelete = await _employeeRepository.GetEmployeeById(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id={id} not found");
                }

                await _employeeRepository.DeleteEmployee(id);
                return Ok($"Employee with Id={id} deleted");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error deleting employee record");
            }
        }
    }
}
