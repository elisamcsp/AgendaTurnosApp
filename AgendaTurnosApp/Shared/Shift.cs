using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Shared
{
    public class Shift
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime ShiftDate { get; set; }

        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
    }
}
