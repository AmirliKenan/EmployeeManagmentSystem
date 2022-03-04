using AutoMapper;
using EmployeeManagmentSystem.Data.Entities;
using EmployeeManagmentSystem.DTOs.DepartmentDto;
using EmployeeManagmentSystem.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            this._departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        [SwaggerOperation(Summary = "Get All  Departments")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.GetDepartments();
            return Ok(departments);
        }
        [SwaggerOperation(Summary = "Get Department  Detail")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById([FromRoute] int id)
        {

            try
            {
                var department = await _departmentRepository.GetDepartmentById(id);
                if (department == null)
                {
                    return NotFound();
                }
                return department;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                      "Something went wrong");
            }
        }
        [SwaggerOperation(Summary = "Create Department")]
        [HttpPost]
        public async Task<ActionResult<string>> Add([FromBody] DepartmentAddDto model)
        {

            var data = _mapper.Map<DepartmentAddDto, Department>(model);
            try
            {
                if (model == null) { return BadRequest(); }
                var newDepartment = await _departmentRepository.AddDepartment(data);
                return CreatedAtAction(nameof(GetDepartmentById),
                    new { id = newDepartment.Id }, newDepartment);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error creating new department record");
            }
        }
        [SwaggerOperation(Summary = "Update Department")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Department>> Update([FromRoute] int id, [FromBody] Department department)
        {
            try
            {
                if (id != department.Id)
                {

                    return BadRequest();
                }
                var employeeToUpdate = await _departmentRepository.GetDepartmentById(id);
                if (employeeToUpdate == null)
                {
                    return NotFound($"Department with Id={id} not found");
                }

                return await _departmentRepository.UpdateDepartment(department);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error updating employee record");
            }
        }
        [SwaggerOperation(Summary = "Delete Department")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {

                var employeeToDelete = await _departmentRepository.GetDepartmentById(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Department with Id={id} not found");
                }

                await _departmentRepository.DeleteDepartment(id);
                return Ok($"Department with Id={id} deleted");

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error deleting employee record");
            }
        }
    }
}
