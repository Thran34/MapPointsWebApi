using Microsoft.AspNetCore.Mvc;

namespace MapPointsWebApi;

[ApiController]
public class PointController : Controller
{
    private static readonly List<Question> Questions = new()
    {
        new("What is the capital of France?", new[] { "Berlin", "London", "Paris", "Madrid" }, 2),
        new("2 + 2 = ?", new[] { "3", "4", "5", "6" }, 1),
        new("The largest planet in the solar system?", new[] { "Earth", "Mars", "Jupiter", "Venus" }, 2),
        new("Author of 'To be or not to be'?", new[] { "Shakespeare", "Dickens", "Tolkien", "Austen" }, 0),
        new("The speed of light?", new[] { "300,000 km/s", "150,000 km/s", "100,000 km/s", "50,000 km/s" }, 0),
        new("Capital of Germany?", new[] { "Berlin", "Paris", "Madrid", "London" }, 0),
        new("The smallest prime number?", new[] { "0", "1", "2", "3" }, 2),
        new("H2O is the chemical formula for?", new[] { "Hydrogen", "Water", "Oxygen", "Helium" }, 1),
        new("The square root of 16?", new[] { "2", "4", "6", "8" }, 1),
        new("The capital of Japan?", new[] { "Beijing", "Tokyo", "Seoul", "Bangkok" }, 1)
    };

    [HttpGet("/api/Point")]
    public Task<List<Point>> GetPoints(double latitude, double longitude, int count)
    {
        var random = new Random();
        var points = Enumerable.Range(0, count).Select(_ =>
        {
            var (lat, lng) = GetRandomLocationWithinRadius(latitude, longitude, 1000, random);
            return new Point(lat, lng, Questions[random.Next(Questions.Count)]);
        }).ToList();

        return Task.FromResult(points);
    }

    private static (double, double) GetRandomLocationWithinRadius(double latitude, double longitude, int radiusInMeters, Random random)
    {
        double radiusInDegrees = radiusInMeters / 111300f; // Approximate conversion from meters to degrees
        double u = random.NextDouble();
        double v = random.NextDouble();
        double w = radiusInDegrees * Math.Sqrt(u);
        double t = 2 * Math.PI * v;
        double deltaLat = w * Math.Cos(t);
        double deltaLng = w * Math.Sin(t) / Math.Cos(latitude * Math.PI / 180);
        return (latitude + deltaLat, longitude + deltaLng);
    }
}