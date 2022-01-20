using AgendaTurnosApp.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Client.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Patient> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Patient>($"api/patient/{id}");
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Patient>>($"api/patient");
        }

        public async Task<bool> SavePatient(Patient patient)
        {
            HttpResponseMessage statusCode = new HttpResponseMessage();

            if (patient.Id == 0)
                statusCode = await _httpClient.PostAsJsonAsync($"api/patient", patient);
            else
                statusCode = await _httpClient.PutAsJsonAsync($"api/patient/{patient.Id}", patient);

            return statusCode.IsSuccessStatusCode;
        }

        public async Task DeletePatient(int id)
        {
            await _httpClient.DeleteAsync($"api/patient/{id}");           
        }
    }
}