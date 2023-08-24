using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Machine
{
    public int MedicalequipmentId { get; set; }

    public bool LicenseIsNeeded { get; set; }

    public virtual Medicalequipment Medicalequipment { get; set; } = null!;
}
