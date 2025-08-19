# Neo-Tracker
Pulls and displays near-Earth object tracking data from NASA's API.  Written in C# and .NET.

# Dependencies
- .NET 8.0 SDK
- ASP.NET Core MVC
- Microsoft.Extensions.Http (for HttpClient)
- Microsoft.Extensions.Caching.Memory (for IMemoryCache)
- Microsoft.Extensions.Configuration (for appsettings.json support)
- Newtonsoft.Json or System.Text.Json (for JSON parsing)
- Bootstrap (for frontend styling, via CDN in views)

# Usage
.NET: If you clone this down to your local machine, you can just use dotnet run, then go to http://localhost:5143/NeoTracker.
