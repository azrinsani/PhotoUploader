using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace photouploader
{
    public partial class MainPage:ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();
        }
    }
}