using System.Collections.Generic;

namespace HospitalAppoinment.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AppointmentMedicine> AppointmentMedicines { get; set; }

    }
}
