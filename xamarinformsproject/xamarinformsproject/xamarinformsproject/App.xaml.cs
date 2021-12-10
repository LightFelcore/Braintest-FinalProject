using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinformsproject.Services;

namespace xamarinformsproject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<APIDataStore>(); // registeer de APIDataStore in de applicatie, eerste werd er gebruik gemaakt van een MockDataStore als test
            // App starting page
            MainPage = new NavigationPage(new MainPage());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
