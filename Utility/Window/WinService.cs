using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Window
{
    /// <summary>
    /// Reference dll: System.ServiceProcess, System.Configuration.Install
    /// </summary>
    public class WinService
    {
        // 서비스 명령 대기 시간 
        public static TimeSpan WAIT_TIME = TimeSpan.FromSeconds(20);

        public static void ServiceListLog()
        {
            var services = ServiceController.GetServices();

            foreach (var service in services)
            {
                Console.WriteLine(service.ServiceName + "[" + service.DisplayName + "] " + service.Status);
            }
        }


        public static ServiceController GetService(string name)
        {
            var services = ServiceController.GetServices();
            ServiceController service = services.FirstOrDefault(x => x.ServiceName == name);
            return service;
        }

        public static bool IsRunning(ServiceController service)
        {
            if (service != null)
            {
                if (service.Status == ServiceControllerStatus.Running)
                    return true;
            }

            return false;
        }

        public static void Start(ServiceController service)
        {
            if (service != null)
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, WAIT_TIME);
            }
        }

        public static void Stop(ServiceController service)
        {
            if (service != null)
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, WAIT_TIME);
            }
        }

        /// <summary>
        /// Service Install Command 지원 함수
        /// </summary>
        public static void Install(string path)
        {
            ManagedInstallerClass.InstallHelper(new string[] { path });
        }

        /// <summary>
        /// Service Uninstall Command 지원 함수
        /// </summary>
        public static void Uninstall(string path)
        {
            ManagedInstallerClass.InstallHelper(new string[] { "/u", path });
        }


        public static void Install(ServiceController service, InstallEventHandler handler = null)
        {
            if (service != null)
            {
                ServiceInstaller installer = new ServiceInstaller();
                installer.Context = new InstallContext();
                installer.ServiceName = service.ServiceName;
                installer.Install(null);

                if (handler != null)
                    installer.AfterInstall += handler;
            }
        }

        public static void Uninstall(ServiceController service, InstallEventHandler handler = null)
        {
            if (service != null)
            {
                ServiceInstaller installer = new ServiceInstaller();
                installer.Context = new InstallContext();
                installer.ServiceName = service.ServiceName;
                installer.Uninstall(null);

                if (handler != null)
                    installer.AfterUninstall += handler;
            }
        }
    }
}
