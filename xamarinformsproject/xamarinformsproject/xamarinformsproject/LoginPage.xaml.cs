using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using xamarinformsproject.ViewModel;

namespace xamarinformsproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        // Declaring a LoginPageViewModel Instance
        LoginPageViewModel lpVM;
        public LoginPage()
        {
            InitializeComponent();

            // Bind the LoginPageViewModel to the LoginPage and init it
            BindingContext = lpVM = new LoginPageViewModel();
        }
    }
}