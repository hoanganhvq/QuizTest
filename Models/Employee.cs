using System;
using System.Collections.Generic;

namespace QuizTest.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public DateTime? StartingDate { get; set; }

    public int? EducationId { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Education? Education { get; set; }
}
