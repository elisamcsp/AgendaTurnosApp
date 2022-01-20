using AgendaTurnosApp.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AgendaTurnosApp.Client.Services
{
    public class ShiftService: IShiftService
    {
        private readonly HttpClient _httpClient;

        public ShiftService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Shift> GetDetails(int id)
        {
            return await _httpClient.GetFromJsonAsync<Shift>($"api/shift/{id}");
        }

        public async Task<IEnumerable<Shift>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Shift>>($"api/shift");
        }

        public async Task<bool> SaveShift(Shift shift)
        {
            HttpResponseMessage statusCode = new HttpResponseMessage();
            if (shift.Id == 0)
            {
                statusCode = await _httpClient.PostAsJsonAsync($"api/shift", shift);                
            }
            else
            {
                statusCode =  await _httpClient.PutAsJsonAsync($"api/shift/{shift.Id}", shift);
            }

            return statusCode.IsSuccessStatusCode;
        }

        public async Task DeleteShift(int id)
        {
            await _httpClient.DeleteAsync($"api/shift/{id}");
        }

        public async Task<IEnumerable<Shift>> GetAllByDate()
        {
            var shifts = await _httpClient.GetFromJsonAsync<IEnumerable<Shift>>($"api/shift/date");

            if (shifts != null)
            {
                return shifts;
            }
            else
            {
                return new List<Shift>();
            }
        }
    }

}
