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
    public partial class RegisterPage : ContentPage
    {
        // Declaring a RegisterPageViewModel Instance
        RegisterPageViewModel rpVM;

        public RegisterPage()
        {
            InitializeComponent();

            // Bind the LoginPageViewModel to the LoginPage and init it
            BindingContext = rpVM = new RegisterPageViewModel();
        }
    }
}