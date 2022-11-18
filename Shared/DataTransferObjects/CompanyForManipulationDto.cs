using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Name is a Required field")]
        [StringLength(50, ErrorMessage = "Number of characters shouldnt exceed 50")]
        string? Name { get; init; }
        [Required(ErrorMessage = "Address is a required field")]
        [StringLength(100, ErrorMessage = "Address length should not exceed 100 characters")]
        string? Address { get; init; }
        string? Country { get; init; }
        IEnumerable<EmployeeCreationDto> Employees;
    }
}
