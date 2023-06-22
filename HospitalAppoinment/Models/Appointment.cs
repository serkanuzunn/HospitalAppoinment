using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppoinment.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public List<AppointmentMedicine> AppointmentMedicines { get; set; }
        public bool IsApproved { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public bool IsFamilyDoctorAppointment { get; set; }

    }
}
