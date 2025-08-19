using System.Text.Json;
using NeoTracker.Models;

namespace NeoTracker.Services
{
    public static class NeoDeserializer
    {
        public static List<NearEarthObject> Deserialize(string json)
        {
            var result = new List<NearEarthObject>();
            using var doc = JsonDocument.Parse(json);
            if (!doc.RootElement.TryGetProperty("near_earth_objects", out var neosByDate))
                return result;

            foreach (var dateProp in neosByDate.EnumerateObject())
            {
                foreach (var neoElem in dateProp.Value.EnumerateArray())
                {
                    var neo = new NearEarthObject
                    {
                        Id = neoElem.GetProperty("id").GetString()!,
                        Name = neoElem.GetProperty("name").GetString()!,
                        AbsoluteMagnitudeH = neoElem.GetProperty("absolute_magnitude_h").GetDouble(),
                        EstimatedDiameterMin = neoElem.GetProperty("estimated_diameter").GetProperty("kilometers").GetProperty("estimated_diameter_min").GetDouble(),
                        EstimatedDiameterMax = neoElem.GetProperty("estimated_diameter").GetProperty("kilometers").GetProperty("estimated_diameter_max").GetDouble(),
                        IsPotentiallyHazardousAsteroid = neoElem.GetProperty("is_potentially_hazardous_asteroid").GetBoolean(),
                        CloseApproachDate = DateTime.Parse(neoElem.GetProperty("close_approach_data")[0].GetProperty("close_approach_date").GetString()!),
                        RelativeVelocity = double.Parse(neoElem.GetProperty("close_approach_data")[0].GetProperty("relative_velocity").GetProperty("kilometers_per_second").GetString()!),
                        MissDistance = double.Parse(neoElem.GetProperty("close_approach_data")[0].GetProperty("miss_distance").GetProperty("miles").GetString()!),
                        OrbitingBody = neoElem.GetProperty("close_approach_data")[0].GetProperty("orbiting_body").GetString()!
                    };
                    result.Add(neo);
                }
            }
            return result;
        }
    }
}
