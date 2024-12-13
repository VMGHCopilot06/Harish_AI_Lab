using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using VehicleInsuranceAPI.IResponsitory;
using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleInsuranceQuoteController : ControllerBase
    {
        private readonly IVehicleInsuranceQuoteRepository _repository;
        private readonly HttpClient _httpClient;
        private readonly ILogger<VehicleInsuranceQuoteController> _logger;
        private readonly IMemoryCache _cache;

        public VehicleInsuranceQuoteController(IVehicleInsuranceQuoteRepository repository, HttpClient httpClient, ILogger<VehicleInsuranceQuoteController> logger, IMemoryCache cache)
        {
            _repository = repository;
            _httpClient = httpClient;
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleInsuranceQuote>> GetAllQuotes()
        {
            try
            {
                return await _repository.GetAllQuotes();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all quotes");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleInsuranceQuote>> GetQuoteById(int id)
        {
            try
            {
                var cacheKey = $"Quote_{id}";
                if (!_cache.TryGetValue(cacheKey, out VehicleInsuranceQuote quote))
                {
                    quote = await _repository.GetQuoteById(id);
                    if (quote == null)
                    {
                        return NotFound();
                    }

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5));

                    _cache.Set(cacheKey, quote, cacheEntryOptions);
                }

                return quote;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching quote with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VehicleInsuranceQuote>> AddQuote(VehicleInsuranceQuote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repository.AddQuote(quote);
                var createdQuote = await _repository.GetQuoteById(quote.QuoteNumber);
                return CreatedAtAction(nameof(GetQuoteById), new { id = createdQuote.QuoteNumber }, createdQuote);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding quote");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuote(int id, VehicleInsuranceQuote quote)
        {
            if (id != quote.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repository.UpdateQuote(quote);
                _cache.Remove($"Quote_{id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating quote");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            try
            {
                await _repository.DeleteQuote(id);
                _cache.Remove($"Quote_{id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting quote with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("claims/{driverId}")]
        public async Task<ActionResult<IEnumerable<ClaimsHistory>>> GetClaimsHistory(int driverId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://dummyapi.com/claims/{driverId}");
                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }

                var claimsHistory = await response.Content.ReadFromJsonAsync<IEnumerable<ClaimsHistory>>();
                return Ok(claimsHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching claims history for driver ID {driverId}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
