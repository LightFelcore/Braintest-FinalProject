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
    public partial class ResultQuizPage : ContentPage
    {
        // Declaring a ResultQuizPageViewModel Instance
        ResultQuizPageViewModel rqpVM;
        public ResultQuizPage(Quiz q, List<String> l, String t)
        {
            InitializeComponent();
            
            // Bind the ResultQuizPageViewModel to the ResultQuizPage and init it
            BindingContext = rqpVM = new ResultQuizPageViewModel(q, l, t);
        }
    }
}