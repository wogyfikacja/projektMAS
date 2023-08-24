using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlazorApp.Models;

namespace BlazorApp.Data
{
    public class AppointmentService : Controller
    {
        private  MasContext _context;
        public AppointmentService(MasContext context)
        {
            _context = context;
        }

        public IQueryable<Appointment> Index()
        {
            return _context.Appointments;
        }
        public IQueryable<Person> GetDoctors()
        {
            return from per in _context.People
                    where per.DoctorSpec != "NONE"
                    select per;
        }
        public IEnumerable<string> getDoctorSurnames()
        {
            return from doc in this.GetDoctors()
                    select doc.Surname;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}