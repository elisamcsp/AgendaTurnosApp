using AgendaTurnosApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Repositories
{
    public interface IPatientRepository
    {
        Task<int> DeltePatient(int id);
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetDetails(int id);
        Task<int> InsertPatient(Patient patient);
        Task<int> UpdatePatient(Patient patient);
    }
}
