using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppoinment.Models
{
    public class AppointmentMedicine
    {
        [Key]
        [Column(Order = 1)]
        public int AppointmentId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MedicineId { get; set; }

        public Appointment Appointment { get; set; }
        public Medicine Medicine { get; set; }
    }
}
