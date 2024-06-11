using CsvHelper;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SpeedTest
{
    public static class SpeedTestCLI
    {
        private static string _cli = System.Configuration.ConfigurationManager.AppSettings["loc"];
        private static string _sid = System.Configuration.ConfigurationManager.AppSettings["ssid"];

        public static SpeedTest PerformSpeedTest()
        {
            using (Process p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = _cli;
                p.StartInfo.Arguments = "-s " + _sid + " --progress=no --format=csv --output-header";

                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                using (var reader = new StringReader(output))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.RegisterClassMap<SpeedTestMap>();
                    var toReturn = csv.GetRecords<SpeedTest>().First();
                    return toReturn;
                }
            }
        }
    }
}
