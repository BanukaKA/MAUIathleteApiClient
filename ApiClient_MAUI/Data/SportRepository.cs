using ApiClient_MAUI.Models;
using ApiClient_MAUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient_MAUI.Data
{
    internal class SportRepository
    {
        private readonly HttpClient client = new HttpClient();

        public SportRepository()
        {
            client.BaseAddress = Jeeves.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Sport>> GetSports()
        {
            HttpResponseMessage response = await client.GetAsync("api/sports");
            if (response.IsSuccessStatusCode)
            {
                List<Sport> sports = await response.Content.ReadAsAsync<List<Sport>>();
                return sports;
            }
            else
            {
                throw new Exception("Could not access the list of Sports.");
            }
        }
        public async Task<Sport> GetSport(int SportID)
        {
            HttpResponseMessage response = await client.GetAsync($"api/sports/{SportID}");
            if (response.IsSuccessStatusCode)
            {
                Sport sport = await response.Content.ReadAsAsync<Sport>();
                return sport;
            }
            else
            {
                throw new Exception("Could not access that Sport.");
            }
        }
    }
}
