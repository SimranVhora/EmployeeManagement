using System;
using System.Collections.Generic;

namespace Employee.Infrastructure.Entities;

public partial class EmployeeDetailsView
{
    public int EmployeeID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int DepartmentID { get; set; }

    public string? DepartmentName { get; set; }

    public decimal Salary { get; set; }

    public string? FormattedJoiningDate { get; set; }

    public int ProjectCount { get; set; }

    public bool IsActive { get; set; }
}
