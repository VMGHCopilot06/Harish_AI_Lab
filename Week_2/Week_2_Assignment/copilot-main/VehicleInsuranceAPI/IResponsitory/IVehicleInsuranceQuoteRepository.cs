using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.IResponsitory
{
    public interface IVehicleInsuranceQuoteRepository
    {
        Task<IEnumerable<VehicleInsuranceQuote>> GetAllQuotes();
        Task<VehicleInsuranceQuote> GetQuoteById(int id);
        Task<VehicleInsuranceQuote> AddQuote(VehicleInsuranceQuote quote);
        Task<VehicleInsuranceQuote> UpdateQuote(VehicleInsuranceQuote quote);
        Task DeleteQuote(int id);
    }
}
