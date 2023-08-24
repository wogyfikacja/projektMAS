using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Appointment
{
    public string PersonPesel { get; set; } = null!;

    public int ServiceIdService { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int IsCancelled { get; set; }

    public virtual Person PersonPeselNavigation { get; set; } = null!;

    public virtual Service ServiceIdServiceNavigation { get; set; } = null!;
}
