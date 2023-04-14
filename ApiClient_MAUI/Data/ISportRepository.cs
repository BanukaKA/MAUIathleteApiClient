using ApiClient_MAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient_MAUI.Data
{
    internal interface ISportRepository
    {
        Task<List<Sport>> GetSports();
        Task<Sport> GetSport(int ID);
    }
}
