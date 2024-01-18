using lab6.Models.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab6.Data
{
    public class ApiDataSource
    {

        private readonly HttpClient client = new()
        {
            BaseAddress = new System.Uri("http://127.0.0.1:5000")
        };

        public async Task<string> ExecuteLab1(string input)
        {
            var json = JsonSerializer.Serialize(new LabRequest { Input = input });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("lab/lab1", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ExecuteLab2(string input)
        {
            var json = JsonSerializer.Serialize(new LabRequest { Input = input });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("lab/lab2", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ExecuteLab3(string input)
        {
            var json = JsonSerializer.Serialize(new LabRequest { Input = input });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("lab/lab3", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<List<ISOCountryCode>> GetISOCountryCodesAsync()
        {
            var response = await client.GetAsync("/iso-country-codes");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ISOCountryCode>>();
        }

        public async Task<List<ISOCountryCode>> GetISOCountryCodesAsync(string id)
        {
            var response = await client.GetAsync($"/iso-country-codes/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ISOCountryCode>>();
        }

        public async Task<List<UKPAFFile>> GetUKPAFFilesAsync()
        {
            var response = await client.GetAsync("/uk-paf-files");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<UKPAFFile>>();
        }

        public async Task<List<UKPAFFile>> GetUKPAFFilesAsync(long id)
        {
            var response = await client.GetAsync($"/uk-paf-files/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<UKPAFFile>>();
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var response = await client.GetAsync("/customers");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Customer>>();
        }

        public async Task<List<Customer>> GetCustomersAsync(long id)
        {
            var response = await client.GetAsync($"/customers/{id}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Customer>>();
        }

        public async Task<List<Customer>> GetCustomersByDatesAsync(string startDate, string endDate)
        {
            var response = await client.GetAsync($"/customers/between-dates?startDate={startDate}&endDate={endDate}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Customer>>();
        }

        public async Task<List<Customer>> GetCustomersByQueryAsync(string query)
        {
            var response = await client.GetAsync($"/customers/search?query={query}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Customer>>();
        }
    }
}
