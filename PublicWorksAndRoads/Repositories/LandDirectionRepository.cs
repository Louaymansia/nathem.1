using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PublicWorksAndRoads.Models;

namespace PublicWorksAndRoads.Repositories
{
    public class LandDirectionRepository
    {
        public void Insert(LandDirection direction)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO LandDirections (
                        RequestId, DirectionName, LandBoundary, LandDimension, BuildingDimension,
                        BuildingSetback, StreetType, StreetNumber, StreetWidth,
                        ParkingBoundary, ParkingDimension, ParkingArea
                    ) VALUES (
                        @RequestId, @DirectionName, @LandBoundary, @LandDimension, @BuildingDimension,
                        @BuildingSetback, @StreetType, @StreetNumber, @StreetWidth,
                        @ParkingBoundary, @ParkingDimension, @ParkingArea
                    )", connection);

                AddParameters(cmd, direction);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(LandDirection direction)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    UPDATE LandDirections SET
                        DirectionName = @DirectionName, LandBoundary = @LandBoundary,
                        LandDimension = @LandDimension, BuildingDimension = @BuildingDimension,
                        BuildingSetback = @BuildingSetback, StreetType = @StreetType,
                        StreetNumber = @StreetNumber, StreetWidth = @StreetWidth,
                        ParkingBoundary = @ParkingBoundary, ParkingDimension = @ParkingDimension,
                        ParkingArea = @ParkingArea
                    WHERE DirectionId = @DirectionId", connection);

                AddParameters(cmd, direction);
                cmd.Parameters.AddWithValue("@DirectionId", direction.DirectionId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteByRequestId(int requestId)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand("DELETE FROM LandDirections WHERE RequestId = @RequestId", connection);
                cmd.Parameters.AddWithValue("@RequestId", requestId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<LandDirection> GetByRequestId(int requestId)
        {
            var results = new List<LandDirection>();
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM LandDirections WHERE RequestId = @RequestId", connection);
                cmd.Parameters.AddWithValue("@RequestId", requestId);
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

        private void AddParameters(SqlCommand cmd, LandDirection direction)
        {
            cmd.Parameters.AddWithValue("@RequestId", direction.RequestId);
            cmd.Parameters.AddWithValue("@DirectionName", (object)direction.DirectionName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LandBoundary", (object)direction.LandBoundary ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LandDimension", (object)direction.LandDimension ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BuildingDimension", (object)direction.BuildingDimension ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@BuildingSetback", (object)direction.BuildingSetback ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StreetType", (object)direction.StreetType ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StreetNumber", (object)direction.StreetNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@StreetWidth", (object)direction.StreetWidth ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ParkingBoundary", (object)direction.ParkingBoundary ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ParkingDimension", (object)direction.ParkingDimension ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ParkingArea", (object)direction.ParkingArea ?? DBNull.Value);
        }

        private LandDirection MapFromReader(SqlDataReader reader)
        {
            return new LandDirection
            {
                DirectionId = reader.GetInt32(reader.GetOrdinal("DirectionId")),
                RequestId = reader.GetInt32(reader.GetOrdinal("RequestId")),
                DirectionName = reader.IsDBNull(reader.GetOrdinal("DirectionName")) ? null : reader.GetString(reader.GetOrdinal("DirectionName")),
                LandBoundary = reader.IsDBNull(reader.GetOrdinal("LandBoundary")) ? null : reader.GetString(reader.GetOrdinal("LandBoundary")),
                LandDimension = reader.IsDBNull(reader.GetOrdinal("LandDimension")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("LandDimension")),
                BuildingDimension = reader.IsDBNull(reader.GetOrdinal("BuildingDimension")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("BuildingDimension")),
                BuildingSetback = reader.IsDBNull(reader.GetOrdinal("BuildingSetback")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("BuildingSetback")),
                StreetType = reader.IsDBNull(reader.GetOrdinal("StreetType")) ? null : reader.GetString(reader.GetOrdinal("StreetType")),
                StreetNumber = reader.IsDBNull(reader.GetOrdinal("StreetNumber")) ? null : reader.GetString(reader.GetOrdinal("StreetNumber")),
                StreetWidth = reader.IsDBNull(reader.GetOrdinal("StreetWidth")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("StreetWidth")),
                ParkingBoundary = reader.IsDBNull(reader.GetOrdinal("ParkingBoundary")) ? null : reader.GetString(reader.GetOrdinal("ParkingBoundary")),
                ParkingDimension = reader.IsDBNull(reader.GetOrdinal("ParkingDimension")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ParkingDimension")),
                ParkingArea = reader.IsDBNull(reader.GetOrdinal("ParkingArea")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("ParkingArea"))
            };
        }
    }
}
