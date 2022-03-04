using AutoMapper;
using EmployeeManagmentSystem.DTOs.EmployeeDto;
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
    }
}
