using System.Globalization;
using CsvHelper.Configuration;

namespace SpeedTest
{
    public sealed class SpeedTestMap : ClassMap<SpeedTest>
    {
        public SpeedTestMap()
    	{
            AutoMap(CultureInfo.InvariantCulture);
    	    Map(m => m.server_name).Name("server name");
	        Map(m => m.server_id).Name("server id");
	        Map(m => m.latency).Name("latency");
	        Map(m => m.jitter).Name("jitter");
	        Map(m => m.packet_loss).Name("packet loss");
	        Map(m => m.download).Name("download");
	        Map(m => m.upload).Name("upload");
	        Map(m => m.download_bytes).Name("download bytes");
	        Map(m => m.upload_bytes).Name("upload bytes");  
  	    }
    }
}