using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length is 60 Characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length is 60 Characters")]
        [StringLength(160)]public string? Address { get; set; }
        [StringLength(50)]public string? Country { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
