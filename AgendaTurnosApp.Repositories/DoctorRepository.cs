using AgendaTurnosApp.Shared;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDbConnection _dbConnection;

        public DoctorRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Doctor> GetDetails(int id)
        {
            string sql = "SELECT * FROM Doctors WHERE Id=@Id";
            Doctor result = await _dbConnection.QueryFirstOrDefaultAsync<Doctor>(sql, new { Id = id });

            return result;
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            string sql = "SELECT * FROM Doctors";

            return await _dbConnection.QueryAsync<Doctor>(sql);
        }

        public async Task<bool> InsertDoctor(Doctor Doctor)
        {
            try
            {
                string sql = @"INSERT INTO Doctors(FirstName, LastName, Phone) VALUES ( @FirstName, @LastName, @Phone)";

                int result = await _dbConnection.ExecuteAsync(sql, new
                {
                    FirstName = Doctor.FirstName,
                    LastName = Doctor.LastName,
                    Phone = Doctor.Phone,
                });

                return result > 0;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateDoctor(Doctor Doctor)
        {
            try
            {
                string sql = @"UPDATE Doctors
                               SET FirstName = @FirstName,
                                   LastName = @LastName,
                                   Phone = @Phone
                               WHERE Id = @Id";

                int result = await _dbConnection.ExecuteAsync(sql, new
                {
                    FirstName = Doctor.FirstName,
                    LastName = Doctor.LastName,
                    Phone = Doctor.Phone,
                    Id = Doctor.Id
                });

                return result > 0;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DelteDoctor(int id)
        {
            try
            {
                string sql = @"DELETE Doctors WHERE Id = @Id";

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