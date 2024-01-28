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
        public event Action OnAppointmentAdded;
        public AppointmentService(MasContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Returns a list of all appointments
        /// </summary>
        /// <returns>IQueryable<Appointment></returns>
        public IQueryable<Appointment> Index()
        {
            return _context.Appointments
                    .Include(a => a.ServiceIdServiceNavigation)
                    .Include(a => a.PersonPeselNavigation);
        }
        /// <summary>
        /// Returns appointments of a chosen doctor
        /// </summary>
        /// <param name="doctor">Person</param>
        /// <returns>IQueryable<Appointment></returns>
        public IQueryable<Appointment> IndexForADoctor(Person doctor){
             return _context.Appointments
                    .Include(a => a.ServiceIdServiceNavigation)
                    .Include(a => a.PersonPeselNavigation)
                    .Include(a => a.ServiceIdServiceNavigation.Appointments)
                    .Where(app=>app.ServiceIdServiceNavigation.DoctorPesel == doctor.Pesel);
        }
        /// <summary>
        /// Returns a list of all doctors
        /// </summary>
        /// <returns>IQueryable<Person></returns>
        public IQueryable<Person> GetDoctors()
        {
            return _context.People
                    .Include(p => p.Appointments)
                    .Include(p => p.Services)
                    .ThenInclude(s => s.Appointments) // Include the Appointments property of each Service object
                    .Where(doc => doc.DoctorSpec != "NONE");
        }
        /// <summary>
        /// Returns a list of all doctors surnames
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        public IEnumerable<string> getDoctorSurnames()
        {
            return from doc in this.GetDoctors()
                    select doc.Surname;
        }
        /// <summary>
        /// Adds an entity to the DBcontext. Compilator decides what object is added here from context.
        /// </summary>
        /// <param name="entity"></param> <summary>
        /// class to be added as an object in a database
        /// </summary>
        public void addToContext(object entity){
            _context.Add(entity);
            _context.SaveChanges();

            OnAppointmentAdded?.Invoke();
        }
        /// <summary>
        /// get list of all clients in a db
        /// </summary>
        /// <returns>IQueryable<Person></returns>
        public IQueryable<Person> GetClients(){
            return _context.People.Where(person=>person.Patient == true);
        }

        /// <summary>
        /// get a list of all services in db
        /// </summary>
        /// <returns>IQueryable<Service></returns>
        public IQueryable<Service> GetServices()
        {
            return _context.Services;
        }
        public IQueryable<Service> GetServicesByDocPESEL(string pesel){
            return this.GetServices()
                                    .Include(service=>service.Appointments)
                                    .Include(service=>service.Appointments)
                                    .ThenInclude(appointment=>appointment.PersonPeselNavigation)     
                                    .Where(service=>service.DoctorPesel == pesel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}