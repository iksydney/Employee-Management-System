using CompanyEmployees.Models;
using Entities.LinkModels;
using Microsoft.CodeAnalysis;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Dynamic;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        /*Task<(IEnumerable<ExpandoObject> employees, MetadataAll metaData)> GetEmployeesAsync(Guid companyId, EmployeeParameters
            employeeParameters, bool trackChanges);*/
        Task<(LinkResponse linkResponse, MetadataAll metaData)> GetEmployeesAsync(Guid companyId, LinkParameters linkParameters, 
            bool trackChanges);
        Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        Task<EmployeeDto> CreateEmployeeForCompany(Guid companyId, EmployeeCreationDto employeeCreationDto, bool trackChanges);
        Task DeleteEmployeeForCmpany(Guid companyId, Guid id, bool trackChanges);
        Task UpdateEmployeeForCompany(Guid companyId,
            Guid id,
            EmployeeForUpdateDto employeeForUpdate,
            bool compTrackChanges,
            bool empTrackChanges);
        Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatch(
            Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee
            employeeEntity);


    }
}
