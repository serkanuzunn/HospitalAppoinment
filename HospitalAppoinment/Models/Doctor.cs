using System.Collections.Generic;

namespace HospitalAppoinment.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        public List<Appointment> Appointments { get; set; }

    }
}
