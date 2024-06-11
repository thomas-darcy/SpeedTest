using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace SpeedTest
{
    public partial class SpeedTestService : ServiceBase
    {
        private volatile bool run = true;

        public SpeedTestService()
        {
            InitializeComponent();

            eventLog = new EventLog("Application")
            {
                Source = "SpeedTestService"
            };
        }

        protected override void OnStart(string[] args)
        {
            run = true;
            new Thread(new ThreadStart(DoWork)).Start();
        }

        protected override void OnStop()
        {
            run = false;
        }

        public void DoWork()
        {
            while (run)
            {
                try
                {
                    SpeedTest results = SpeedTestCLI.PerformSpeedTest();
                    DataAccess.Persist(results);
                    Thread.Sleep(900000);
                }
                catch (Exception e)
                {
                    eventLog.WriteEntry("Unhandled Exception: " + e.Message, EventLogEntryType.Error);
                    DataAccess.Persist(new SpeedTest());
                    Thread.Sleep(900000);
                }
            }
        }
    }
}
