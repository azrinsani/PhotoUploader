using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using photouploader.Core;
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
            
            Services.DeviceService = new DeviceService();
            UIApplication.Main(args, null, "AppDelegate");
            
        }
    }
}