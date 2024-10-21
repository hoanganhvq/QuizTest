using System;
using System.Collections.Generic;

namespace QuizTest.Models;

public partial class Education
{
    public int EducationId { get; set; }

    public string? EducationName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
