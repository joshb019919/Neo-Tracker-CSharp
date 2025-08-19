using Neo_Tracker_C_.Models;
using Microsoft.Extensions.Caching.Memory;

namespace NeoTracker.Services
{
    public class NeoTrackerService : INeoTrackerService
    {
    private readonly HttpClient _httpClient;
    private const string _nasaApiUrl = "https://api.nasa.gov/neo/rest/v1/feed";
    private readonly string _apiKey;
    private readonly IMemoryCache _cache;
    private readonly Neo_Tracker_C_.Data.NeoTrackerDbContext _dbContext;

        public NeoTrackerService(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache, Neo_Tracker_C_.Data.NeoTrackerDbContext dbContext)
        {
            _httpClient = httpClient;
            _apiKey = configuration["NasaApi:ApiKey"] ?? "DEMO_KEY";
            _cache = cache;
            _dbContext = dbContext;
        }

        public List<NearEarthObject> GetNearEarthObjects(string startDate, string endDate)
        {
            // IMemoryCache implementation to cache results
            var cacheKey = $"{startDate}:{endDate}";
            if (_cache.TryGetValue(cacheKey, out List<NearEarthObject>? cachedResult))
            {
                return cachedResult!;
            }

            // Fetch data from NASA API
            var url = $"{_nasaApiUrl}?start_date={startDate}&end_date={endDate}&api_key={_apiKey}";
            var response = _httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var json = response.Content.ReadAsStringAsync().Result;
            var result = NeoDeserializer.Deserialize(json);

            // Store new NEOs in the database if not already present
            var existingIds = new HashSet<string>(_dbContext.NearEarthObjects
                .Where(neo => neo.Id != null)
                .Select(neo => neo.Id!));
            var newNeos = result.Where(neo => neo.Id != null && !existingIds.Contains(neo.Id)).ToList();
            if (newNeos.Any())
            {
                _dbContext.NearEarthObjects.AddRange(newNeos);
                _dbContext.SaveChanges();
            }

            _cache.Set(cacheKey, result, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1) });
            return result;
        }
    }
}
