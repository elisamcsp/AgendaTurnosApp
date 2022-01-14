using AgendaTurnosApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Repositories.Shifts
{
    public interface IShiftRepository
    {
        Task<int> DelteShift(int id);
        Task<IEnumerable<Shift>> GetAll();
        Task<IEnumerable<Shift>> GetAllByDate(DateTime shiftDate);
        Task<Shift> GetDetails(int id);
        Task<bool> InsertShift(Shift Shift);
        Task<bool> UpdateShift(Shift Shift);
    }
}
