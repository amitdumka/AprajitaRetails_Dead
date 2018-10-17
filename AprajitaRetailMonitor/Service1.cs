//using AprajitaRetails.Utils;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace AprajitaRetailMonitor
{
    public partial class Service1 : ServiceBase
    {
        private System.Diagnostics.EventLog eventLog1;
        private int eventId = 1;
        public Watcher fileWatcher1;//, fileWatcher2;

        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus( System.IntPtr handle, ref ServiceStatus serviceStatus );

        public Service1( )
        {
            InitializeComponent();

            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("AprajitaRetailsMonitor"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "AprajitaRetailsMonitor", "AprajitaRetailsLog");
            }
            eventLog1.Source = "AprajitaRetailsMonitor";
            eventLog1.Log = "AprajitaRetailsLog";
            fileWatcher1 = new Watcher(eventLog1);
            // fileWatcher2 = new Watcher(eventLog1);
        }

        protected override void OnStart( string[] args )
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            eventLog1.WriteEntry("In OnStart");
            //Code between this line

            fileWatcher1.Watch(PathList.InvoiceXMLFile, PathList.InvoiceXMLPath);
            // fileWatcher2.Watch(PathList.TabletSaleXMLFile, PathList.TabletSaleXMLPath);

            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        protected override void OnStop( )
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            eventLog1.WriteEntry("In OnStop");
            //User code above line

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        public void OnTimer( object sender, System.Timers.ElapsedEventArgs args )
        {
            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
        }

        protected override void OnContinue( )
        {
            eventLog1.WriteEntry("In OnContinue.");
        }
    }

    public class PathList
    {
        public const string InvoiceXMLPath = "C:\\Capillary";
        public const string TabletSaleXMLPath = "D:\\VoyagerRetail\\TabletSale";
        public const string InvoiceXMLFile = "invoice.xml";
        public const string TabletSaleXMLFile = "TabletBill.XML";
        public const string TailoringHubXMLPath = "D:\\VoyagerRetail\\TailoringHub";
    }
}