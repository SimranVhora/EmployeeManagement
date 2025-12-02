using System;
using System.Collections.Generic;

namespace Employee.Infrastructure.Entities;

public partial class Employees
{
    public int EmployeeID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int DepartmentID { get; set; }

    public decimal Salary { get; set; }

    public DateOnly DateOfJoining { get; set; }

    public bool IsActive { get; set; }

    public virtual Departments Department { get; set; } = null!;

    public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();
}
