using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Service
{
    public int IdService { get; set; }

    public int Price { get; set; }

    public int Room { get; set; }

    public string DoctorPesel { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Person DoctorPeselNavigation { get; set; } = null!;

    public virtual ICollection<Medicalequipment> Medicalequipments { get; set; } = new List<Medicalequipment>();

    public virtual ICollection<Person> PersonPesels { get; set; } = new List<Person>();
}
