using System.Collections.Generic;

namespace AgendaTurnosApp.Shared
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
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