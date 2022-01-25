using FreshMvvm;
using Xamarin.Forms.Xaml;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace photouploader
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();
            FreshIOC.Container.Register<IAppService, AppService>();
            FreshIOC.Container.Resolve<IDeviceService>().SetTopStatusBar(AzUtil.Core.Color.FromHex("#000000"));
            var page = FreshPageModelResolver.ResolvePageModel<MainPageModel> ();  
            var basicNavContainer = new FreshNavigationContainer(page);  
            MainPage = basicNavContainer; 
            
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}