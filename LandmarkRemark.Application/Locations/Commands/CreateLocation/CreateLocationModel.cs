using System.ComponentModel.DataAnnotations;

namespace LandmarkRemark.Application.Locations.Commands.CreateLocation
{
    public class CreateLocationModel
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string Remark { get; set; }
    }
}
