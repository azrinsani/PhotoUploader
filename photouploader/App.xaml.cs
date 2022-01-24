using System;
using photouploader.Core;
using photouploader.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace photouploader
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            Services.MainVM = (MainVM) this.BindingContext;
            Services.AppService = new AppService();
            Services.MainVM.Initialize();
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