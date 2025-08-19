using Microsoft.AspNetCore.Mvc;
using NeoTracker.Services;

namespace NeoTracker.Controllers
{
    public class NeoTrackerController : Controller
    {
        private readonly INeoTrackerService _neoTrackerService;

        public NeoTrackerController(INeoTrackerService neoTrackerService)
        {
            _neoTrackerService = neoTrackerService;
        }

        public IActionResult Index(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate))
                startDate = DateTime.Now.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(endDate))
                endDate = DateTime.Now.ToString("yyyy-MM-dd");

            var neos = _neoTrackerService.GetNearEarthObjects(startDate, endDate);
            return View(neos);
        }
    }
}
