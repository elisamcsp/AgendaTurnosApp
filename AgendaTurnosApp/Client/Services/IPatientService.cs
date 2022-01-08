using AgendaTurnosApp.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Client.Services
{
    public interface IPatientService
    {
        Task DeletePatient(int id);
        Task<IEnumerable<Patient>> GetAll();
        Task<Patient> GetDetails(int id);
        Task SavePatient(Patient patient);
    }
}
