using System;
using System.Collections.Generic;

namespace BlazorApp.Models;

public partial class Person
{
    public override string ToString()
    {
        return Name + " " + Surname;
    }
    public string Pesel { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public bool Patient { get; set; }

    public bool Worker { get; set; }

    public string DoctorSpec { get; set; } = null!;

    public string NurseSpec { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Dayofwork> Dayofworks { get; set; } = new List<Dayofwork>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Service> ServiceIdServices { get; set; } = new List<Service>();
}
