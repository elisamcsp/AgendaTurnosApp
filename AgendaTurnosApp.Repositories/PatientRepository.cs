using AgendaTurnosApp.Shared.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnection _dbConnection;

        public PatientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            string sql = "SELECT * FROM Patients";           

            return (IEnumerable<Patient>)await _dbConnection.QueryAsync<IEnumerable<Patient>>(sql, new { });
        }

        public async Task<Patient> GetDetails(int id)
        {
            string sql = "SELECT * FROM Patients WHERE Id=@Id";
            Patient result = await _dbConnection.QueryFirstOrDefaultAsync<Patient>(sql, new { Id = id });

            return result;
        
        }

        public async Task<int> InsertPatient(Patient patient)
        {
            string sql = @"INSERT INTO Patients(DNI, FirstName, LastName, BirthDate, Phone, Address)
                            VALUES (@DNI, @FirstName, @LastName, @BirthDate, @Phone, @Address)";

            int result = await _dbConnection.ExecuteAsync(sql, new
                            {
                                DNI = patient.DNI,
                                FirstName = patient.FirstName,
                                LastName = patient.LastName,
                                BirthDate = patient.BirthDate,
                                Phone = patient.Phone,
                                Address = patient.Address
                            });

            return result;
        }

        public async Task<int> UpdatePatient(Patient patient)
        {
            string sql = @"UPDATE Patients
                            SET DNI = @DNI, 
                                FirstName = @FirstName,     
                                LastName = @LastName,
                                BirthDate = @BirthDate, 
                                Phone = @Phone, 
                                Address = @Address
                            WHERE Id = @Id";

            int result = await _dbConnection.ExecuteAsync(sql, new
            {
                DNI = patient.DNI,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                BirthDate = patient.BirthDate,
                Phone = patient.Phone,
                Address = patient.Address,
                Id = patient.Id 
            });

            return result;
        }

        public async Task<int> DeltePatient(int id)
        {
            string sql = @"DELETE Patients WHERE Id = @Id";

            int result = await _dbConnection.ExecuteAsync(sql, new {Id = id });

            return result;
        }
    }
}
