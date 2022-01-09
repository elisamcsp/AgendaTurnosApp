using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Shared
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]        
        public string FirstName { get; set; }
        [Required(ErrorMessage ="El campo Apellidos es obligatorio")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]        
        public string DNI { get; set; }
        [Required(ErrorMessage = "El campo Fecha Nacimiento es obligatorio")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
