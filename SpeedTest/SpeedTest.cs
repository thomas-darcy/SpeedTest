namespace SpeedTest
{
    public class SpeedTest
    {
        public string server_name { get; set; }
        public int server_id { get; set; }
        public double latency { get; set; }
        public double jitter { get; set; }
        public double packet_loss { get; set; }
        public long download { get; set; }
        public long upload { get; set; }
        public long download_bytes { get; set; }
        public long upload_bytes { get; set; }

        public SpeedTest() 
        {
            server_name = "Failure";
            server_id = 0;
            latency = 0.00;
            jitter = 0.00;
            packet_loss = 0.00;
            download = 0;
            upload = 0;
            download_bytes = 0;
            upload_bytes = 0;
        }

        public SpeedTest(string sn, int si, double l, double j, double pl, long d, long u, long db, long ub)
        {
            server_name = sn;
            server_id = si;
            latency = l;
            jitter = j;
            packet_loss = pl;
            download = d;
            upload = u;
            download_bytes = db;
            upload_bytes = ub;
        }
    }
}
