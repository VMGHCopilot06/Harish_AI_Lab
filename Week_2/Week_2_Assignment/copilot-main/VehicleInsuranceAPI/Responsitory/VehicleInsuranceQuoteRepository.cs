using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehicleInsuranceAPI.DataAccess;
using VehicleInsuranceAPI.IResponsitory;
using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.Responsitory
{
    public class VehicleInsuranceQuoteRepository : IVehicleInsuranceQuoteRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<VehicleInsuranceQuoteRepository> _logger;

        public VehicleInsuranceQuoteRepository(AppDbContext context, ILogger<VehicleInsuranceQuoteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<VehicleInsuranceQuote>> GetAllQuotes()
        {
            try
            {
                return await _context.VehicleInsuranceQuotes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all quotes");
                throw;
            }
        }

        public async Task<VehicleInsuranceQuote> GetQuoteById(int id)
        {
            try
            {
                return await _context.VehicleInsuranceQuotes.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching quote with ID {id}");
                throw;
            }
        }

        public async Task<VehicleInsuranceQuote> AddQuote(VehicleInsuranceQuote quote)
        {
            try
            {
                _context.VehicleInsuranceQuotes.Add(quote);
                await _context.SaveChangesAsync();
                return quote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding quote");
                throw;
            }
        }

        public async Task<VehicleInsuranceQuote> UpdateQuote(VehicleInsuranceQuote quote)
        {
            try
            {
                _context.Entry(quote).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return quote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating quote");
                throw;
            }
        }

        public async Task DeleteQuote(int id)
        {
            try
            {
                var quote = await _context.VehicleInsuranceQuotes.FindAsync(id);
                if (quote != null)
                {
                    _context.VehicleInsuranceQuotes.Remove(quote);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting quote with ID {id}");
                throw;
            }
        }
    }
}
