namespace PublicWorksAndRoads.Models
{
    public class LandDirection
    {
        public int DirectionId { get; set; }
        public int RequestId { get; set; }
        public string DirectionName { get; set; }
        public string LandBoundary { get; set; }
        public decimal? LandDimension { get; set; }
        public decimal? BuildingDimension { get; set; }
        public decimal? BuildingSetback { get; set; }
        public string StreetType { get; set; }
        public string StreetNumber { get; set; }
        public decimal? StreetWidth { get; set; }
        public string ParkingBoundary { get; set; }
        public decimal? ParkingDimension { get; set; }
        public decimal? ParkingArea { get; set; }
    }
}
