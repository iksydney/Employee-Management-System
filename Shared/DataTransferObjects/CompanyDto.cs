using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    //[Serializable]
    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? FullAddress { get; init; }
    }
    public record CompanyForCreationDto (
        [Required(ErrorMessage = "Name is a Required field")]
        [StringLength(50, ErrorMessage = "Number of characters shouldnt exceed 50")]
        string? Name,
        [Required(ErrorMessage = "Address is a required field")]
        [StringLength(100, ErrorMessage = "Address length should not exceed 100 characters")]
        string? Address,
        string? Country,
        IEnumerable<EmployeeCreationDto> Employees
    );
    public record CompanyForUpdateDto(
        string Name, 
        string Address, 
        string Country, 
        IEnumerable<EmployeeCreationDto> Employees
    );

}
