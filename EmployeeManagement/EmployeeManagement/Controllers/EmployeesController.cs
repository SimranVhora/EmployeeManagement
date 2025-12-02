using Employee.Application.DTOs;
using Employee.Application.Interfaces;
using Employee.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController(IEmployeeRepository repo) : ControllerBase
{
    private readonly IEmployeeRepository _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _repo.GetAllEmployeesAsync();
        return Ok(data);
    }

    [HttpGet("department/{id}")]
    public async Task<IActionResult> GetByDepartment(int id)
    {
        var data = await _repo.GetEmployeesByDepartmentAsync(id);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddEmployeeRequest request)
    {
        var result = await _repo.AddEmployeeAsync(request);
        return Ok(new { Message = "Employee added successfully" });
    }

    [HttpGet("projects")]
    public async Task<IActionResult> GetProjectSummary()
    {
        var data = await _repo.GetEmployeeProjectSummaryAsync();
        return Ok(data);
    }
    [HttpGet("departments")]
    public async Task<IActionResult> GetDepartments()
    {
        var result = await _repo.GetDepartmentsAsync();
        return Ok(result);
    }

    [HttpPost("filter")]
    public async Task<IActionResult> FilterEmployees([FromBody] EmployeeFilterRequestDto filter)
    {
        var result = await _repo.GetEmployeesByFilter(filter);
        return Ok(result);
    }

    [HttpGet("analytics/avg-salary-by-department")]
    public async Task<IActionResult> GetAvgSalaryByDepartment([FromServices] EmployeeDbContext context)
    {
        // Advanced LINQ: grouping + aggregation + projection
        var data = await context.Employees
            .GroupBy(e => new { e.DepartmentID, e.Department.DepartmentName })
            .Select(g => new {
                DepartmentID = g.Key.DepartmentID,
                DepartmentName = g.Key.DepartmentName,
                EmployeeCount = g.Count(),
                AverageSalary = Math.Round(g.Average(e => e.Salary), 2)
            })
            .OrderByDescending(x => x.AverageSalary)
            .ToListAsync();

        return Ok(data);
    }

}

