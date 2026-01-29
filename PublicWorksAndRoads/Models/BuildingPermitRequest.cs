using System;

namespace PublicWorksAndRoads.Models
{
    public class BuildingPermitRequest
    {
        public int RequestId { get; set; }
        public string EntityName { get; set; }
        public string FormNumber { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantPhone { get; set; }
        public string LicenseType { get; set; }
        public string RegionName { get; set; }
        public string UnitName { get; set; }
        public string BuildFloor { get; set; }
        public string ApplicantSignature { get; set; }
        public string AreaEngineerName { get; set; }
        public string AreaEngineerSignature { get; set; }
        public string ReviewEngineerName { get; set; }
        public string ReviewEngineerSignature { get; set; }
        public decimal? LandAreaSurvey { get; set; }
        public decimal? LandAreaProjection { get; set; }
        public decimal? BuildingArea { get; set; }
        public string ExistingBuilding { get; set; }
        public string LicensedMaterialPrev { get; set; }
        public string LicensePurpose { get; set; }
        public string BlockType { get; set; }
        public string FloorsToLicense { get; set; }
        public string LicensedMaterial { get; set; }
        public int? PreviousShopOpenings { get; set; }
        public int? RequestedShopOpenings { get; set; }
        public decimal? ParkingAreaTotal { get; set; }
        public string LandLayer { get; set; }
        public string Curb { get; set; }
        public string MiddleSetback { get; set; }
        public string LandLocationFromFlood { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
