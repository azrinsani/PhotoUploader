using FreshMvvm;
using UIKit;

namespace photouploader.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            FreshIOC.Container.Register<IDeviceService, DeviceService>();
            UIApplication.Main(args, null, "AppDelegate");
            
        }
    }
}