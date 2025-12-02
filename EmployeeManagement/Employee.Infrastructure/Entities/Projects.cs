using System;
using System.Collections.Generic;

namespace Employee.Infrastructure.Entities;

public partial class Projects
{
    public int ProjectID { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; } = new List<EmployeeProjects>();
}
