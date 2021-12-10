using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarinformsproject.ViewModel;

namespace xamarinformsproject
{
    public partial class MainPage : ContentPage
    {
        // Declaring a MainPageViewModel Instance
        MainPageViewModel mpVM;

        public MainPage()
        {
            InitializeComponent();

            // Bind the MainPageViewModel to the MainPage and init it
            BindingContext = mpVM = new MainPageViewModel();
        }

        
        protected override void OnAppearing()
        {
            mpVM.LoadQuizData();
        }
    }
}
