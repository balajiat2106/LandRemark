namespace LandmarkRemark.Application.UserLocation.Queries
{
    public class UserLocationListModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Label { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Remark { get; set; }
    }
}