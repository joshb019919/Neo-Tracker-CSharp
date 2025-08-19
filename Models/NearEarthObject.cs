
using System.ComponentModel.DataAnnotations;
namespace Neo_Tracker_C_.Models
{
    public class NearEarthObject
    {
    [Key]
    public string? Id { get; set; }
        public string? Name { get; set; }
        public double AbsoluteMagnitudeH { get; set; }
        public double EstimatedDiameterMin { get; set; }
        public double EstimatedDiameterMax { get; set; }
        public bool IsPotentiallyHazardousAsteroid { get; set; }
        public DateTime CloseApproachDate { get; set; }
        public double RelativeVelocity { get; set; }
        public double MissDistance { get; set; }
        public string? OrbitingBody { get; set; }
    }
}
