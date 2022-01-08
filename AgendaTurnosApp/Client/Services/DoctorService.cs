using AgendaTurnosApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Client.Services
{
    public class DoctorService: IDoctorService
    {
        private readonly HttpClient _httpClient;

        public DoctorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Doctor> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Doctor>($"api/doctor/{id}");
        }

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Doctor>>($"api/doctor");
        }

        public async Task SaveDoctor(Doctor doctor)
        {
            if (doctor.Id == 0)
                await _httpClient.PostAsJsonAsync($"api/doctor", doctor);
            else
                await _httpClient.PutAsJsonAsync($"api/doctor/{doctor.Id}", doctor);
        }

        public async Task DeleteDoctor(int id)
        {
            await _httpClient.DeleteAsync($"api/doctor/{id}");
        }
    }

}
