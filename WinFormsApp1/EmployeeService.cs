using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace WinFormsApp1
{
    internal class EmployeeService
    {
        static HttpClient client = new HttpClient();

        public void createConnection()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:8080/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Employee> GetEmployees(long? departmentId, string? role)
        {
            List<Employee> employees = null;
            string apiUrl = "api/employee/filter";

            // Add parameters to the URL if they are not null
            if (departmentId.HasValue || !string.IsNullOrEmpty(role))
            {
                var parameters = new List<string>();
                if (departmentId.HasValue)
                {
                    parameters.Add($"departmentId={departmentId}");
                }
                if (!string.IsNullOrEmpty(role))
                {
                    parameters.Add($"role={Uri.EscapeDataString(role)}");
                }

                apiUrl += "?" + string.Join("&", parameters);
            }

            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string resultString = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("gata : " + resultString);
                employees = JsonSerializer.Deserialize<List<Employee>>(resultString);
                return employees;
            }
            return null;
        }

    }
}
