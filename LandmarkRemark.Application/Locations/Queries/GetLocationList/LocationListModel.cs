namespace LandmarkRemark.Application.Locations.Queries.GetLocationList
{
    public class LocationListModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Remark { get; set; }
        public int UserId { get; set; }
    }
}