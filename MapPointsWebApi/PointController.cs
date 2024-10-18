using Microsoft.AspNetCore.Mvc;

namespace MapPointsWebApi;

public class PointController : Controller
{
    // GET
    [HttpGet("/api/Point")]
    public  Task<Point[]> GetPoints()
    {
        var random = new Random();
        return Task.FromResult(new[]
        {
            new Point(random.Next(0, 10), random.Next(0, 3))
        });
    }
}