using System.ComponentModel.DataAnnotations;

namespace Employee.Application.DTOs;
public class AddEmployeeRequest
{
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required, EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public int DepartmentID { get; set; }

    [Required]
    [Range(1, double.MaxValue)]
    public decimal Salary { get; set; }

    [Required]
    public DateTime DateOfJoining { get; set; }

    public bool IsActive { get; set; } = true;
}
