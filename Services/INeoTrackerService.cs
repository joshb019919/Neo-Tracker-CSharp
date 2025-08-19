using Neo_Tracker_C_.Models;

namespace NeoTracker.Services
{
    public interface INeoTrackerService
    {
        List<NearEarthObject> GetNearEarthObjects(string startDate, string endDate);
    }
}
