using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Medicalequipment
{
    public int Id { get; set; }

    public int Price { get; set; }

    public int Width { get; set; }

    public int Depth { get; set; }

    public int Height { get; set; }

    public string Descript { get; set; } = null!;

    public int Room { get; set; }

    public virtual Machine? Machine { get; set; }

    public virtual Tool? Tool { get; set; }

    public virtual ICollection<Service> ServiceIdServices { get; set; } = new List<Service>();
}
