using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Shared.Entities
{
    public class Shift
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime ShiftDate { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
