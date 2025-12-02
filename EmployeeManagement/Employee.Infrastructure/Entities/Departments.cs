namespace Employee.Infrastructure.Entities;

public partial class Departments
{
    public int DepartmentID { get; set; }

    public string DepartmentName { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Employees> Employees { get; set; } = new List<Employees>();
}
