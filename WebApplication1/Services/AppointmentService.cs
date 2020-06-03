using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _db;

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateAppointment(Appointment appointment)
        {
            appointment.ProductId = appointment.Product.Id;
            appointment.Product = null;
            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return true;
        }

        public List<Appointment> GetAppointments()
        {
            return _db.Appointments.ToList();
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            _db.Appointments.Remove(appointment);
            return true;
        }
    }
}
