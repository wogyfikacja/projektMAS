using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Dayofwork
{
    public DateOnly Date { get; set; }

    public TimeOnly Start { get; set; }

    public TimeOnly End { get; set; }

    public string Pesel { get; set; } = null!;

    public virtual Person PeselNavigation { get; set; } = null!;
}
