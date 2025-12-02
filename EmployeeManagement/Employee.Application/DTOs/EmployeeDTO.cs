namespace Employee.Application.DTOs;

public record EmployeeDTO(
    int EmployeeID,
    string FirstName,
    string LastName,
    string Email,
    string DepartmentName,
    decimal Salary,
    string FormattedJoiningDate,
    int ProjectCount,
    bool IsActive
);
