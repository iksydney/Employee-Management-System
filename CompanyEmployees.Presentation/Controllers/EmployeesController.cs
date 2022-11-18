using ActionFilters;
using Entities.LinkModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public EmployeesController(IServiceManager serviceManager) => _serviceManager = serviceManager;


        [HttpGet]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId, 
            [FromQuery] EmployeeParameters employeeParameters)
        {
            var linkParams = new LinkParameters(employeeParameters, HttpContext);
            var result = await _serviceManager.EmployeeService.GetEmployeesAsync(companyId,
            linkParams, trackChanges: false);
            Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(result.metaData));
            return result.linkResponse.HasLinks ? Ok(result.linkResponse.LinkedEntities) : 
                Ok(result.linkResponse.ShapedEntities);
        }
        /*[HttpGet]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetEmployees(Guid companyId, [FromQuery] EmployeeParameters employeeParameters)
        {
            *//*var employees = await _serviceManager.EmployeeService.GetEmployeesAsync(companyId, employeeParameters, trackChanges: false);

            return Ok(employees);*//*

            var linkParams = new LinkParameters(employeeParameters, HttpContext);
            var pagedResult = await _serviceManager.EmployeeService.GetEmployeesAsync(companyId, linkParams, trackChanges: false);

            *//*var pagedResult = await _serviceManager.EmployeeService.GetEmployeesAsync(companyId, employeeParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.employees);*//*
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.employees);

        }*/

        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployeesForCompany(Guid companyId, Guid id)
        {
            var employee = await _serviceManager.EmployeeService.GetEmployeeAsync(companyId, id,
            trackChanges: false);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Guid companyId, [FromBody] EmployeeCreationDto employee)
        {
            if (employee is null)
                return BadRequest("Employee to be created is empty");
            if(!ModelState.IsValid)
                return UnprocessableEntity();

            var employeeToReturn = await _serviceManager.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.id }, employeeToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            _serviceManager.EmployeeService.DeleteEmployeeForCmpany(companyId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, 
            [FromBody] EmployeeForUpdateDto employee)
        {
            if (employee is null)
                return BadRequest("Employee for update object is null");
            _serviceManager.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, compTrackChanges: false, empTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(Guid companyId, Guid id, 
            [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = await _serviceManager.EmployeeService.GetEmployeeForPatch(companyId, id,
            compTrackChanges: false,
            empTrackChanges: true);

            patchDoc.ApplyTo(result.employeeToPatch, ModelState);

            TryValidateModel(result.employeeToPatch);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _serviceManager.EmployeeService.SaveChangesForPatch(result.employeeToPatch,
            result.employeeEntity);
            return NoContent();
        }
    }
}
