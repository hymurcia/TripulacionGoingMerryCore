using System;
using System.Collections.Generic;

namespace TripulacionGoingMerry.Models;

public partial class Tripulant
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
