using System;
using System.Threading.Tasks;
using RouteOptimizer.Models;

namespace RouteOptimizer.Services
{
    public interface IRoutetService
    {
        string Currency { get; }

        Task<Route> Find(string from, string to, DateTime periodStart, DateTime periodEnd);
    }
}