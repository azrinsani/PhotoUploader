using System;
using Android.OS;
using AzUtil.Core;
using photouploader.Core;
using Xamarin.Essentials;
using Xamarin.Forms.Platform.Android;
using Platform = Xamarin.Essentials.Platform;

namespace photouploader.Droid
{
    public class DeviceService:IDeviceService
    {
        public void SetTopStatusBar(Color color)
        {
            if (Platform.CurrentActivity.Window != null)
                Platform.CurrentActivity.Window.SetStatusBarColor(color.ToXamarinColor().ToAndroid());
        }
    }
}