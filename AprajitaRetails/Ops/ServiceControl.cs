using System.ServiceProcess;

namespace AprajitaRetails.Ops
{
    public class ServiceControl
    {
        public static string serviceName = "Service1";
        public static ServiceController controller = new ServiceController(serviceName);

        public static void Stop( )
        {
            if (controller.Status == ServiceControllerStatus.Running)
                controller.Stop();
        }

        public static void Start( )
        {
            if (controller.Status == ServiceControllerStatus.Stopped)
                controller.Start();
        }
    }
}