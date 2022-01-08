using AgendaTurnosApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Repositories
{
    public interface IDoctorRepository
    {
        Task<int> DelteDoctor(int id);
        Task<IEnumerable<Doctor>> GetAll();
        Task<Doctor> GetDetails(int id);
        Task<bool> InsertDoctor(Doctor Doctor);
        Task<bool> UpdateDoctor(Doctor Doctor);
    }
}
