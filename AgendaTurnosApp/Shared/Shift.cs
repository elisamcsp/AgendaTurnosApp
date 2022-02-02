using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Shared
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un Doctor")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un Paciente")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una Fecha")]
        public DateTime ShiftDate { get; set; }

        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
    }
}
