using Android.App;
using Android.Content.PM;
using Android.OS;
using photouploader.Core;
using Xamarin.Forms.Platform.Android;


namespace photouploader.Droid
{
    [Activity(Label = "photouploader", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Services.DeviceService = new DeviceService();
            LoadApplication(new App());
        }
    }
}