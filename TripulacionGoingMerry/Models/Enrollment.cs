using System;
using System.Collections.Generic;

namespace TripulacionGoingMerry.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int TripulantId { get; set; }

    public virtual Tripulant Tripulant { get; set; } = null!;
}
