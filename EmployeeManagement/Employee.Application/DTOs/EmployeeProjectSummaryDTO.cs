namespace Employee.Application.DTOs;
public record EmployeeProjectSummaryDTO(
    int EmployeeID,
    string FirstName,
    string LastName,
    string Email,
    string DepartmentName,
    int ProjectCount
);
