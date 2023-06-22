using HospitalAppoinment.Data;
using HospitalAppoinment.Models;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace HospitalAppoinment.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class AppointmentsController:ControllerBase
    {
        private readonly HospitalContext _context;

        public AppointmentsController(HospitalContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAppointments()
        {
            var appointments = _context.Appointments
                .Include(a => a.AppointmentMedicines)
                .ThenInclude(am => am.Medicine)
                .ToList();

            return Ok(appointments);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddAppointment(Appointment appointment)
        {
            appointment.IsFamilyDoctorAppointment = false;

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return Ok(appointment);
        }

        [HttpPost]
        [Route("approve")]
        public IActionResult ApproveAppointment(int appointmentId)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
            if (appointment == null)
            {
                return NotFound();
            }

            appointment.IsApproved = true;
            _context.SaveChanges();
            return Ok(appointment);
        }

        [HttpPost]
        [Route("reject")]
        public IActionResult RejectAppointment(int appointmentId)
        {
            var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == appointmentId);
            if (appointment == null)
            {
                return NotFound();
            }

            appointment.IsApproved = false;
            _context.SaveChanges();
            return Ok(appointment);
        }

        [HttpPost]
        [Route("addmedicine")]
        public IActionResult AddMedicineToAppointment(int appointmentId, int medicineId)
        {
            var appointment = _context.Appointments.Include(a => a.AppointmentMedicines).FirstOrDefault(a => a.AppointmentId == appointmentId);
            if (appointment == null)
            {
                return NotFound();
            }

            var medicine = _context.Medicines.Find(medicineId);
            if (medicine == null)
            {
                return NotFound("Medicine not found.");
            }

            appointment.AppointmentMedicines.Add(new AppointmentMedicine { MedicineId = medicineId, AppointmentId = appointmentId });
            _context.SaveChanges();
            return Ok(appointment);
        }


        [HttpPost]
        [Route("setfamilydoctor")]
        public IActionResult SetFamilyDoctor(int patientId, int doctorId, DateTime startDate)
        {
            var familyDoctor = new FamilyDoctor
            {
                PatientId = patientId,
                DoctorId = doctorId,
                StartDate = startDate
            };

            _context.FamilyDoctors.Add(familyDoctor);
            _context.SaveChanges();
            return Ok(familyDoctor);
        }

        [HttpPost]
        [Route("updatefamilydoctor")]
        public IActionResult UpdateFamilyDoctor(int patientId, int doctorId, DateTime startDate, DateTime? endDate)
        {
            var familyDoctor = _context.FamilyDoctors.FirstOrDefault(fd => fd.PatientId == patientId);
            if (familyDoctor == null)
            {
                return NotFound();
            }

            familyDoctor.DoctorId = doctorId;
            familyDoctor.StartDate = startDate;
            familyDoctor.EndDate = endDate;
            _context.SaveChanges();
            return Ok(familyDoctor);
        }

        [HttpGet]
        [Route("getfamilydoctor")]
        public IActionResult GetFamilyDoctor(int patientId)
        {
            var familyDoctor = _context.FamilyDoctors
                .Include(fd => fd.Doctor)
                .FirstOrDefault(fd => fd.PatientId == patientId);

            if (familyDoctor == null)
            {
                return NotFound();
            }

            return Ok(familyDoctor);
        }

        [HttpGet]
        [Route("getfamilydoctorsbydate")]
        public IActionResult GetFamilyDoctorsByDate(DateTime date)
        {
            var familyDoctors = _context.FamilyDoctors
                .Include(fd => fd.Doctor)
                .Where(fd => fd.StartDate <= date && (fd.EndDate == null || fd.EndDate >= date))
                .ToList();

            return Ok(familyDoctors);
        }
    }
}
