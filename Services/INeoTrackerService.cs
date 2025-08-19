using NeoTracker.Models;

namespace NeoTracker.Services
{
    public interface INeoTrackerService
    {
        List<NearEarthObject> GetNearEarthObjects(string startDate, string endDate);
    }
}
