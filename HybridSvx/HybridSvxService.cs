using System.ServiceProcess;
using System.Timers;

namespace HybridSvx
{
    partial class HybridSvxService : ServiceBase
    {
        private static Timer aTimer;

        public HybridSvxService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new Timer(10000); // 10 Seconds
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            DataProcessor dataProcessor = new DataProcessor();
            dataProcessor.Execute();
        }

        protected override void OnStop()
        {
            aTimer.Stop();
        }

    }
}
