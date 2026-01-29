using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PublicWorksAndRoads.Models;

namespace PublicWorksAndRoads.Repositories
{
    public class BuildingPermitRepository
    {
        public int Insert(BuildingPermitRequest request)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO BuildingPermitRequests (
                        EntityName, FormNumber, ApplicantName, ApplicantPhone, LicenseType,
                        RegionName, UnitName, BuildFloor, ApplicantSignature,
                        AreaEngineerName, AreaEngineerSignature, ReviewEngineerName, ReviewEngineerSignature,
                        LandAreaSurvey, LandAreaProjection, BuildingArea, ExistingBuilding,
                        LicensedMaterialPrev, LicensePurpose, BlockType, FloorsToLicense,
                        LicensedMaterial, PreviousShopOpenings, RequestedShopOpenings,
                        ParkingAreaTotal, LandLayer, Curb, MiddleSetback, LandLocationFromFlood, CreatedAt
                    ) VALUES (
                        @EntityName, @FormNumber, @ApplicantName, @ApplicantPhone, @LicenseType,
                        @RegionName, @UnitName, @BuildFloor, @ApplicantSignature,
                        @AreaEngineerName, @AreaEngineerSignature, @ReviewEngineerName, @ReviewEngineerSignature,
                        @LandAreaSurvey, @LandAreaProjection, @BuildingArea, @ExistingBuilding,
                        @LicensedMaterialPrev, @LicensePurpose, @BlockType, @FloorsToLicense,
                        @LicensedMaterial, @PreviousShopOpenings, @RequestedShopOpenings,
                        @ParkingAreaTotal, @LandLayer, @Curb, @MiddleSetback, @LandLocationFromFlood, @CreatedAt
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", connection);

                AddParameters(cmd, request);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(BuildingPermitRequest request)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    UPDATE BuildingPermitRequests SET
                        EntityName = @EntityName, FormNumber = @FormNumber, ApplicantName = @ApplicantName,
                        ApplicantPhone = @ApplicantPhone, LicenseType = @LicenseType,
                        RegionName = @RegionName, UnitName = @UnitName, BuildFloor = @BuildFloor,
                        ApplicantSignature = @ApplicantSignature,
                        AreaEngineerName = @AreaEngineerName, AreaEngineerSignature = @AreaEngineerSignature,
                        ReviewEngineerName = @ReviewEngineerName, ReviewEngineerSignature = @ReviewEngineerSignature,
                        LandAreaSurvey = @LandAreaSurvey, LandAreaProjection = @LandAreaProjection,
                        BuildingArea = @BuildingArea, ExistingBuilding = @ExistingBuilding,
                        LicensedMaterialPrev = @LicensedMaterialPrev, LicensePurpose = @LicensePurpose,
                        BlockType = @BlockType, FloorsToLicense = @FloorsToLicense,
                        LicensedMaterial = @LicensedMaterial, PreviousShopOpenings = @PreviousShopOpenings,
                        RequestedShopOpenings = @RequestedShopOpenings, ParkingAreaTotal = @ParkingAreaTotal,
                        LandLayer = @LandLayer, Curb = @Curb, MiddleSetback = @MiddleSetback,
                        LandLocationFromFlood = @LandLocationFromFlood
                    WHERE RequestId = @RequestId", connection);

                AddParameters(cmd, request);
                cmd.Parameters.AddWithValue("@RequestId", request.RequestId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int requestId)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand("DELETE FROM BuildingPermitRequests WHERE RequestId = @RequestId", connection);
                cmd.Parameters.AddWithValue("@RequestId", requestId);
                cmd.ExecuteNonQuery();
            }
        }

        public BuildingPermitRequest GetById(int requestId)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM BuildingPermitRequests WHERE RequestId = @RequestId", connection);
                cmd.Parameters.AddWithValue("@RequestId", requestId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return MapFromReader(reader);
                    return null;
                }
            }
        }

        public List<BuildingPermitRequest> Search(string searchTerm)
        {
            var results = new List<BuildingPermitRequest>();
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    SELECT * FROM BuildingPermitRequests
                    WHERE FormNumber LIKE @SearchTerm 
                       OR ApplicantName LIKE @SearchTerm
                       OR CAST(RequestId AS NVARCHAR) LIKE @SearchTerm
                    ORDER BY CreatedAt DESC", connection);
                cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(MapFromReader(reader));
                    }
                }
            }
            return results;
        }

        public List<BuildingPermitRequest> GetAll()
        {
            var results = new List<BuildingPermitRequest>();
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM BuildingPermitRequests ORDER BY CreatedAt DESC", connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(MapFromReader(reader));
                    }
                }
            }
            return results;
        }

        private void AddParameters(SqlCommand cmd, BuildingPermitRequest request)
        {
            cmd.Parameters.AddWithValue("@EntityName", (object)request.EntityName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FormNumber", (object)request.FormNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ApplicantName", (object)request.ApplicantName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ApplicantPhone", (object)request.ApplicantPhone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LicenseType", (object)request.LicenseType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RegionName", (object)request.RegionName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@UnitName", (object)request.UnitName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BuildFloor", (object)request.BuildFloor ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ApplicantSignature", (object)request.ApplicantSignature ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AreaEngineerName", (object)request.AreaEngineerName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@AreaEngineerSignature", (object)request.AreaEngineerSignature ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReviewEngineerName", (object)request.ReviewEngineerName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReviewEngineerSignature", (object)request.ReviewEngineerSignature ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LandAreaSurvey", (object)request.LandAreaSurvey ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LandAreaProjection", (object)request.LandAreaProjection ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BuildingArea", (object)request.BuildingArea ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ExistingBuilding", (object)request.ExistingBuilding ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LicensedMaterialPrev", (object)request.LicensedMaterialPrev ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LicensePurpose", (object)request.LicensePurpose ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BlockType", (object)request.BlockType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FloorsToLicense", (object)request.FloorsToLicense ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LicensedMaterial", (object)request.LicensedMaterial ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PreviousShopOpenings", (object)request.PreviousShopOpenings ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@RequestedShopOpenings", (object)request.RequestedShopOpenings ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ParkingAreaTotal", (object)request.ParkingAreaTotal ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LandLayer", (object)request.LandLayer ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Curb", (object)request.Curb ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MiddleSetback", (object)request.MiddleSetback ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LandLocationFromFlood", (object)request.LandLocationFromFlood ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedAt", request.CreatedAt == DateTime.MinValue ? DateTime.Now : request.CreatedAt);
        }

        private BuildingPermitRequest MapFromReader(SqlDataReader reader)
        {
            return new BuildingPermitRequest
            {
                RequestId = reader.GetInt32(reader.GetOrdinal("RequestId")),
                EntityName = reader.IsDBNull(reader.GetOrdinal("EntityName")) ? null : reader.GetString(reader.GetOrdinal("EntityName")),
                FormNumber = reader.IsDBNull(reader.GetOrdinal("FormNumber")) ? null : reader.GetString(reader.GetOrdinal("FormNumber")),
                ApplicantName = reader.IsDBNull(reader.GetOrdinal("ApplicantName")) ? null : reader.GetString(reader.GetOrdinal("ApplicantName")),
                ApplicantPhone = reader.IsDBNull(reader.GetOrdinal("ApplicantPhone")) ? null : reader.GetString(reader.GetOrdinal("ApplicantPhone")),
                LicenseType = reader.IsDBNull(reader.GetOrdinal("LicenseType")) ? null : reader.GetString(reader.GetOrdinal("LicenseType")),
                RegionName = reader.IsDBNull(reader.GetOrdinal("RegionName")) ? null : reader.GetString(reader.GetOrdinal("RegionName")),
                UnitName = reader.IsDBNull(reader.GetOrdinal("UnitName")) ? null : reader.GetString(reader.GetOrdinal("UnitName")),
                BuildFloor = reader.IsDBNull(reader.GetOrdinal("BuildFloor")) ? null : reader.GetString(reader.GetOrdinal("BuildFloor")),
                ApplicantSignature = reader.IsDBNull(reader.GetOrdinal("ApplicantSignature")) ? null : reader.GetString(reader.GetOrdinal("ApplicantSignature")),
                AreaEngineerName = reader.IsDBNull(reader.GetOrdinal("AreaEngineerName")) ? null : reader.GetString(reader.GetOrdinal("AreaEngineerName")),
                AreaEngineerSignature = reader.IsDBNull(reader.GetOrdinal("AreaEngineerSignature")) ? null : reader.GetString(reader.GetOrdinal("AreaEngineerSignature")),
                ReviewEngineerName = reader.IsDBNull(reader.GetOrdinal("ReviewEngineerName")) ? null : reader.GetString(reader.GetOrdinal("ReviewEngineerName")),
                ReviewEngineerSignature = reader.IsDBNull(reader.GetOrdinal("ReviewEngineerSignature")) ? null : reader.GetString(reader.GetOrdinal("ReviewEngineerSignature")),
                LandAreaSurvey = reader.IsDBNull(reader.GetOrdinal("LandAreaSurvey")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("LandAreaSurvey")),
                LandAreaProjection = reader.IsDBNull(reader.GetOrdinal("LandAreaProjection")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("LandAreaProjection")),
                BuildingArea = reader.IsDBNull(reader.GetOrdinal("BuildingArea")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("BuildingArea")),
                ExistingBuilding = reader.IsDBNull(reader.GetOrdinal("ExistingBuilding")) ? null : reader.GetString(reader.GetOrdinal("ExistingBuilding")),
                LicensedMaterialPrev = reader.IsDBNull(reader.GetOrdinal("LicensedMaterialPrev")) ? null : reader.GetString(reader.GetOrdinal("LicensedMaterialPrev")),
                LicensePurpose = reader.IsDBNull(reader.GetOrdinal("LicensePurpose")) ? null : reader.GetString(reader.GetOrdinal("LicensePurpose")),
                BlockType = reader.IsDBNull(reader.GetOrdinal("BlockType")) ? null : reader.GetString(reader.GetOrdinal("BlockType")),
                FloorsToLicense = reader.IsDBNull(reader.GetOrdinal("FloorsToLicense")) ? null : reader.GetString(reader.GetOrdinal("FloorsToLicense")),
                LicensedMaterial = reader.IsDBNull(reader.GetOrdinal("LicensedMaterial")) ? null : reader.GetString(reader.GetOrdinal("LicensedMaterial")),
                PreviousShopOpenings = reader.IsDBNull(reader.GetOrdinal("PreviousShopOpenings")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("PreviousShopOpenings")),
                RequestedShopOpenings = reader.IsDBNull(reader.GetOrdinal("RequestedShopOpenings")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("RequestedShopOpenings")),
                ParkingAreaTotal = reader.IsDBNull(reader.GetOrdinal("ParkingAreaTotal")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ParkingAreaTotal")),
                LandLayer = reader.IsDBNull(reader.GetOrdinal("LandLayer")) ? null : reader.GetString(reader.GetOrdinal("LandLayer")),
                Curb = reader.IsDBNull(reader.GetOrdinal("Curb")) ? null : reader.GetString(reader.GetOrdinal("Curb")),
                MiddleSetback = reader.IsDBNull(reader.GetOrdinal("MiddleSetback")) ? null : reader.GetString(reader.GetOrdinal("MiddleSetback")),
                LandLocationFromFlood = reader.IsDBNull(reader.GetOrdinal("LandLocationFromFlood")) ? null : reader.GetString(reader.GetOrdinal("LandLocationFromFlood")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };
        }
    }
}
