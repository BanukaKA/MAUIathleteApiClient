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
    internal class AthleteRepository
    {
        private readonly HttpClient client = new HttpClient();

        public AthleteRepository()
        {
            client.BaseAddress = Jeeves.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Athlete>> GetAthletes()
        {
            HttpResponseMessage response = await client.GetAsync("api/athletes");
            if (response.IsSuccessStatusCode)
            {
                List<Athlete> athletes = await response.Content.ReadAsAsync<List<Athlete>>();
                return athletes;
            }
            else
            {
                throw new Exception("Could not access the list of Athletes.");
            }
        }

        public async Task<List<Athlete>> GetAthletesByLeague(int SportID)
        {
            HttpResponseMessage response = await client.GetAsync($"api/athletes/bySport{SportID}");
            if (response.IsSuccessStatusCode)
            {
                List<Athlete> athletes = await response.Content.ReadAsAsync<List<Athlete>>();
                return athletes;
            }
            else
            {
                throw new Exception("Could not access the list of Athletes by Sport.");
            }
        }


        public async Task<Athlete> GetAthlete(int AthleteID)
        {
            HttpResponseMessage response = await client.GetAsync($"api/athletes/{AthleteID}");
            if (response.IsSuccessStatusCode)
            {
                Athlete athlete = await response.Content.ReadAsAsync<Athlete>();
                return athlete;
            }
            else
            {
                throw new Exception("Could not access that Athlete.");
            }
        }
    }
}
