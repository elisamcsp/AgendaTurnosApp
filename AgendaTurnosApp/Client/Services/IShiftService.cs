using AgendaTurnosApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Client.Services
{
    public interface IShiftService
    {
        Task DeleteShift(int id);
        Task<IEnumerable<Shift>> GetAll();
        Task<Shift> GetDetails(int id);
        Task SaveShift(Shift shift);
    }
}
