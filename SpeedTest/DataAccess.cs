using System.Data;
using System.Data.SqlClient;

namespace SpeedTest
{
    public class DataAccess
    {
        private static string connection = System.Configuration.ConfigurationManager.AppSettings["cs"];
        public static void Persist(SpeedTest data) 
        {
            var query = @"INSERT INTO [dbo].[SpeedTest]" +
                        "([server name],[server id],[latency],[jitter],[packet loss],[download],[upload],[download bytes],[upload bytes])" +
                        "VALUES" +
                        "(@sn,@si,@l,@j,@pl,@d,@u,@db,@ub)";

            using (SqlConnection cn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@sn", SqlDbType.VarChar, 128).Value = data.server_name;
                cmd.Parameters.Add("@si", SqlDbType.Int).Value = data.server_id;
                cmd.Parameters.Add("@l", SqlDbType.Float).Value = data.latency;
                cmd.Parameters.Add("@j", SqlDbType.Float).Value = data.jitter;
                cmd.Parameters.Add("@pl", SqlDbType.Float).Value = data.packet_loss;
                cmd.Parameters.Add("@d", SqlDbType.BigInt).Value = data.download;
                cmd.Parameters.Add("@u", SqlDbType.BigInt).Value = data.upload;
                cmd.Parameters.Add("@db", SqlDbType.BigInt).Value = data.download_bytes;
                cmd.Parameters.Add("@ub", SqlDbType.BigInt).Value = data.upload_bytes;

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}
