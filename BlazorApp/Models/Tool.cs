using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Tool
{
    public int MedicalequipmentId { get; set; }

    public int Material { get; set; }

    public virtual Medicalequipment Medicalequipment { get; set; } = null!;
}
