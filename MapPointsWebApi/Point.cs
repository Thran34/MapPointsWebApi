namespace MapPointsWebApi;

public class Point
{
    public Point(double lat, double lng, Question question)
    {
        Latitude = lat;
        Longitude = lng;
        Question = question;
    }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Question Question { get; set; }
}