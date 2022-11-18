using CompanyEmployees.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        { }

        public void CreateEmployee(Guid CompanyId, Employee employee)
        {
            employee.CompanyId = CompanyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
            => await FindByCondition(c => c.CompanyId.Equals(companyId) && id.Equals(id), trackChanges)
            .FirstOrDefaultAsync();

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            /*var employees = await FindByCondition(e => e.CompanyId.Equals(companyId),
           trackChanges)*/
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId) && 
                            (e.Age >= employeeParameters.MinAge && e.Age <= employeeParameters.MaxAge), trackChanges)

            .OrderBy(e => e.Name)
            .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
            .Search(employeeParameters.SearchTerm)
            .Sort(employeeParameters.OrderBy)
            .Skip((employeeParameters.pageNumber - 1) * employeeParameters.pageSize)
            .Take(employeeParameters.pageSize)
            .ToListAsync();

            var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges ).CountAsync();


            /*return PagedList<Employee>
            .ToPagedList(employees, employeeParameters.pageNumber,
           employeeParameters.pageSize);*/
            return new PagedList<Employee>(employees, count, employeeParameters.pageNumber, employeeParameters.pageSize);
        }

    }
}
