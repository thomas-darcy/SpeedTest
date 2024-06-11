using System.ServiceProcess;

namespace SpeedTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SpeedTestService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
