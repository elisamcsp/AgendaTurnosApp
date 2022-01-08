using AgendaTurnosApp.Shared;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Repositories.Shifts
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly IDbConnection _dbConnection;

        public ShiftRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Shift> GetDetails(int id)
        {
            string sql = "SELECT * FROM Shifts WHERE Id=@Id";
            Shift result = await _dbConnection.QueryFirstOrDefaultAsync<Shift>(sql, new { Id = id });

            return result;
        }

        public async Task<IEnumerable<Shift>> GetAll()
        {
            string sql = "SELECT * FROM Shifts";

            return await _dbConnection.QueryAsync<Shift>(sql);
        }

        public async Task<bool> InsertShift(Shift Shift)
        {
            try
            {
                string sql = @"INSERT INTO Shifts(PatientId, DoctorId, ShiftDate) VALUES ( @PatientId, @DoctorId, @ShiftDate)";

                int result = await _dbConnection.ExecuteAsync(sql, new
                {
                    PatientId = Shift.PatientId,
                    DoctorId = Shift.DoctorId,
                    ShiftDate = Shift.ShiftDate,
                });

                return result > 0;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateShift(Shift Shift)
        {
            try
            {
                string sql = @"UPDATE Shifts
                               SET PatientId = @PatientId,
                                   DoctorId = @DoctorId,
                                   ShiftDate = @ShiftDate
                               WHERE Id = @Id";

                int result = await _dbConnection.ExecuteAsync(sql, new
                {
                    PatientId = Shift.PatientId,
                    DoctorId = Shift.DoctorId,
                    ShiftDate = Shift.ShiftDate,
                    Id = Shift.Id
                });

                return result > 0;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DelteShift(int id)
        {
            try
            {
                string sql = @"DELETE Shifts WHERE Id = @Id";

                int result = await _dbConnection.ExecuteAsync(sql, new { Id = id });

                return result;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
