using AgendaTurnosApp.Shared.Entities;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Client.Services
{
    public class PatientService
    {
        private readonly HttpClient _httpClient;

        public PatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<Patient>> GetAll()
        {
            try
            {
                return _httpClient.GetFromJsonAsync<IEnumerable<Patient>>("/api/patient");
            }
            catch (AccessTokenNotAvailableException exception )
            {
                exception.Redirect();
                throw;
            }
        }
    }
}
