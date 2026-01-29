using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PublicWorksAndRoads.Models;

namespace PublicWorksAndRoads.Repositories
{
    public class SketchRepository
    {
        public void Insert(Sketch sketch)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Sketches (RequestId, SketchType, SketchImage)
                    VALUES (@RequestId, @SketchType, @SketchImage)", connection);

                cmd.Parameters.AddWithValue("@RequestId", sketch.RequestId);
                cmd.Parameters.AddWithValue("@SketchType", (object)sketch.SketchType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SketchImage", (object)sketch.SketchImage ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Sketch sketch)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand(@"
                    UPDATE Sketches SET
                        SketchType = @SketchType, SketchImage = @SketchImage
                    WHERE SketchId = @SketchId", connection);

                cmd.Parameters.AddWithValue("@SketchId", sketch.SketchId);
                cmd.Parameters.AddWithValue("@SketchType", (object)sketch.SketchType ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SketchImage", (object)sketch.SketchImage ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteByRequestId(int requestId)
        {
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand("DELETE FROM Sketches WHERE RequestId = @RequestId", connection);
                cmd.Parameters.AddWithValue("@RequestId", requestId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Sketch> GetByRequestId(int requestId)
        {
            var results = new List<Sketch>();
            using (var connection = Database.CreateConnection())
            {
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM Sketches WHERE RequestId = @RequestId", connection);
                cmd.Parameters.AddWithValue("@RequestId", requestId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new Sketch
                        {
                            SketchId = reader.GetInt32(reader.GetOrdinal("SketchId")),
                            RequestId = reader.GetInt32(reader.GetOrdinal("RequestId")),
                            SketchType = reader.IsDBNull(reader.GetOrdinal("SketchType")) ? null : reader.GetString(reader.GetOrdinal("SketchType")),
                            SketchImage = reader.IsDBNull(reader.GetOrdinal("SketchImage")) ? null : (byte[])reader["SketchImage"]
                        });
                    }
                }
            }
            return results;
        }
    }
}
