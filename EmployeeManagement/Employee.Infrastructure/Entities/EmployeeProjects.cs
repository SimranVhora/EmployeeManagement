using System;
using System.Collections.Generic;

namespace Employee.Infrastructure.Entities;

public partial class EmployeeProjects
{
    public int ID { get; set; }

    public int EmployeeID { get; set; }

    public int ProjectID { get; set; }

    public DateOnly AssignedDate { get; set; }

    public virtual Employees Employee { get; set; } = null!;

    public virtual Projects Project { get; set; } = null!;
}
internal class EmployeeProjectSummaryDTO
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public int ProjectCount { get; set; }
}
