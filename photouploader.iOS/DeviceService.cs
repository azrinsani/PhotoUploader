using System;
using AzUtil.Core;
using Foundation;
using photouploader.Core;
using UIKit;

namespace photouploader.iOS
{
    public class DeviceService:IDeviceService
    {
        public void SetTopStatusBar(Color color)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                // If VS has updated to the latest version , you can use StatusBarManager , else use the first line code
                // UIView statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame);
                if (UIApplication.SharedApplication.KeyWindow.WindowScene != null &&
                    UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager != null)
                {
                    UIView statusBar = new UIView(UIApplication.SharedApplication.KeyWindow.WindowScene.StatusBarManager.StatusBarFrame);
                    statusBar.BackgroundColor = new UIColor(new nfloat(color.R), new nfloat(color.G),
                        new nfloat(color.B), new nfloat(color.A));
                    UIApplication.SharedApplication.KeyWindow.AddSubview(statusBar);
                }
            }
            else
            {
                UIView statusBar = (UIView) UIApplication.SharedApplication.ValueForKey(new NSString("statusBar"));
                if (statusBar != null && statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
                {
                    statusBar.BackgroundColor = new UIColor(new nfloat(color.R), new nfloat(color.G),
                        new nfloat(color.B), new nfloat(color.A));
                    UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.BlackOpaque;
                }
            }
        }

    }
}