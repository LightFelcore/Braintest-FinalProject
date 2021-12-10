using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarinformsproject.Model;
using xamarinformsproject.ViewModel;

namespace xamarinformsproject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakeQuizPage : ContentPage
    {
        TakeQuizPageViewModel tqpVM;

        public TakeQuizPage(Quiz q)
        {
            InitializeComponent();

            // Bind the TakeQuizPageViewModel to the TakeQuizPage and init it
            BindingContext = tqpVM = new TakeQuizPageViewModel(q);
        }
        protected override void OnAppearing()
        {
            tqpVM.OnAppearing();
        }
    }
    
}