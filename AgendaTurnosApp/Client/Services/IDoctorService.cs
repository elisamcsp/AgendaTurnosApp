using AgendaTurnosApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Client.Services
{
    public interface IDoctorService
    {
        Task DeleteDoctor(int id);
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetDetails(int id);
        Task SaveDoctor(Doctor doctor);
    }
}
