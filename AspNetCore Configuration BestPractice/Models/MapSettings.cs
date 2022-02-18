namespace AspNetCore_Configuration_BestPractice.Models
{
    public class MapSettings
    {
        public int DefaultZoomLevel { get; set; }
        public Location DefaultLocation { get; set; }
    }
    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

}
