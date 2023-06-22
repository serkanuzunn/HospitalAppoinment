using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppoinment.Models
{
    public class FamilyDoctor
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
