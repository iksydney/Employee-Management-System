using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EmployeeDto(Guid id, string Name, int Age, string Position);
    public record EmployeeCreationDto : EmployeeForManipulationDto;
    /*{
        [Required(ErrorMessage = "Employee Name is a required field")]
        [MaxLength(30, ErrorMessage = "Maximum Character for Employee Name is 30")]
        string? Name { get; init; }
        [Required(ErrorMessage = "Age is a required field")]
        [Range(18, 90, ErrorMessage = "Age cant be less than 18 and not more than 90")]
        int Age { get; init; }
        [Required(ErrorMessage = "Position is a required field")]
        [MaxLength(20, ErrorMessage = "Maximum character of position is 50")]
        string? Position { get; init; }
    }*/
    public record EmployeeForUpdateDto : EmployeeForManipulationDto;
    /*{
        string Name { get; init; }
        int Age { get; init; }
        string Position { get; init; }
    }*/
}
