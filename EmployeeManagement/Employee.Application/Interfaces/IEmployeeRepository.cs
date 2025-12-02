using Employee.Application.DTOs;
using Employee.Infrastructure.Entities;
using System.Linq.Expressions;
namespace Employee.Application.Interfaces;

public interface IEmployeeRepository : IRepository<Employees>
{
    Task<IEnumerable<EmployeeDetailsView>> GetAllEmployeesAsync();
    Task<IEnumerable<Employees>> GetEmployeesByDepartmentAsync(int departmentId);
    Task<int> AddEmployeeAsync(AddEmployeeRequest request);
    Task<IEnumerable<EmployeeProjectSummaryDTO>> GetEmployeeProjectSummaryAsync();
    Task<IEnumerable<Departments>> GetDepartmentsAsync();
    Task<IEnumerable<Employees>> GetEmployeesByFilter(EmployeeFilterRequestDto request);
}