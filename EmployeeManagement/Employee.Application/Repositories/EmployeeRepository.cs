using Employee.Application.DTOs;
using Employee.Application.Interfaces;
using Employee.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Employee.Application.Repositories;


public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext _context;

    public EmployeeRepository(EmployeeDbContext context)
    {
        _context = context;
    }

    // ------- 1. Get All Employees using View -------
    public async Task<IEnumerable<EmployeeDetailsView>> GetAllEmployeesAsync()
    {
        return await _context.EmployeeDetailsView.ToListAsync();
    }

    // ------- 2. Employees by Department (SP) -------
    public async Task<IEnumerable<Employees>> GetEmployeesByDepartmentAsync(int departmentId)
    {
        return await _context.Employees
            .FromSqlRaw("EXEC sp_GetEmployeesByDepartment @DeptId",
            new SqlParameter("@DeptId", departmentId))
            .ToListAsync();
    }

    // ------- 3. Add Employee using SP -------
    public async Task<int> AddEmployeeAsync(AddEmployeeRequest request)
    {
        var parameters = new[]
        {
            new SqlParameter("@FirstName", request.FirstName),
            new SqlParameter("@LastName", request.LastName),
            new SqlParameter("@Email", request.Email),
            new SqlParameter("@DepartmentID", request.DepartmentID),
            new SqlParameter("@Salary", request.Salary),
            new SqlParameter("@DateOfJoining", request.DateOfJoining),
            new SqlParameter("@IsActive", request.IsActive)
        };

        var result = await _context.Database
            .ExecuteSqlRawAsync("EXEC sp_AddNewEmployee @FirstName, @LastName, @Email, @DepartmentID, @Salary, @DateOfJoining, @IsActive",
            parameters);

        return result;
    }

    // ------- 4. Project Summary -------
    public async Task<IEnumerable<EmployeeProjectSummaryDTO>> GetEmployeeProjectSummaryAsync()
    {
        return await _context.Set<EmployeeProjectSummaryDTO>()
             .FromSqlRaw("EXEC sp_GetEmployeeProjectSummary")
             .ToListAsync();
    }
    public async Task<IEnumerable<Departments>> GetDepartmentsAsync() =>
       await _context.Departments.ToListAsync();

    public async Task<IEnumerable<Employees>> GetEmployeesByFilter(EmployeeFilterRequestDto req)
    {
        var query = _context.Employees.AsQueryable();

        if (req.MinSalary.HasValue)
            query = query.Where(e => e.Salary >= req.MinSalary);

        if (req.MaxSalary.HasValue)
            query = query.Where(e => e.Salary <= req.MaxSalary);

        if (req.StartDate.HasValue)
            query = query.Where(e => e.DateOfJoining >= req.StartDate);

        if (req.EndDate.HasValue)
            query = query.Where(e => e.DateOfJoining <= req.EndDate);

        if (req.IsActive.HasValue)
            query = query.Where(e => e.IsActive == req.IsActive);

        if (req.DepartmentID.HasValue)
            query = query.Where(e => e.DepartmentID == req.DepartmentID);

        return await query.ToListAsync();
    }

}
