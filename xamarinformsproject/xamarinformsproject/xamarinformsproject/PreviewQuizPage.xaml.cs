using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarinformsproject.Model;
using xamarinformsproject.ViewModel;

namespace xamarinformsproject
{
    public partial class PreviewQuizPage : ContentPage
    {
        PreviewQuizPageViewModel pqpVM;
        public PreviewQuizPage(Quiz q)
        {
            InitializeComponent();

            // Bind the MainPageViewModel to the MainPage and init it
            BindingContext = pqpVM = new PreviewQuizPageViewModel(q);
        }
    }
}