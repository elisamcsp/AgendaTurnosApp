using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaTurnosApp.Shared
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        public string LastName { get; set; }
        public string Phone { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }        
    }
}