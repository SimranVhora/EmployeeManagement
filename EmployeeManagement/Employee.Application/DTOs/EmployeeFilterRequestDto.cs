namespace Employee.Application.DTOs;

public class EmployeeFilterRequestDto
{
    public int? DepartmentID { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool? IsActive { get; set; }
}
