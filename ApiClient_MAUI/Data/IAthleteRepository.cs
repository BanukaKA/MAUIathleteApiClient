using ApiClient_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient_MAUI.Data
{
    internal interface IAthleteRepository
    {
        Task<List<Athlete>> GetAthletes();
        Task<Athlete> GetAthlete(int ID);
        Task<List<Athlete>> GetAthletesByLeague(int SportID);
    }
}
