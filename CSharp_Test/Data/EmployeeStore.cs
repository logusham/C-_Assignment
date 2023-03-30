using CSharp_Test.Models;
using Newtonsoft.Json;

namespace CSharp_Test.Data
{
    public class EmployeeStore
    {
        private readonly string baseURL;
        HttpClientHandler _clientHandler = new HttpClientHandler();
        public EmployeeStore()
        {
            baseURL = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";
        }
        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employes = new List<Employee>();
            try
            {
                using (var client = new HttpClient(_clientHandler))
                {
                    using (var response = await client.GetAsync(baseURL))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        employes = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                    }

                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return employes;
        }
    }
}
