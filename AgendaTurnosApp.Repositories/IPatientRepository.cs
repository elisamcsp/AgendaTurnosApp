using AgendaTurnosApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Repositories
{
    public interface IPatientRepository
    {
        Task<int> DeltePatient(int id);
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetDetails(int id);
        Task<bool> InsertPatient(Patient patient);
        Task<bool> UpdatePatient(Patient patient);
    }
}
