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
    public partial class CreateQuizPage : ContentPage
    {
        // Declaring a CreateQuizPageViewModel Instance
        CreateQuizPageViewModel cqpVM;
        public CreateQuizPage()
        {
            InitializeComponent();

            PreviewQuizData.IsVisible = false;

            // Bind the CreateQuizPageViewModel to the CreateQuizPage and init it
            BindingContext = cqpVM = new CreateQuizPageViewModel();
        }

        async private void ToNextStepCreatingQuiz(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(NameE.Text) && !string.IsNullOrWhiteSpace(NameE.Text))
            {
                NameSL.IsVisible = false;
                NameL.IsVisible = false;
                NextStepCreateQuiz.IsVisible = false;

                QASL.IsVisible = true;
                QAL.IsVisible = true;
                AddQuestionToQuiz.IsVisible = true;
                PreviewQuizData.IsVisible = true;
            } else
            {
                await App.Current.MainPage.DisplayAlert("Don't leave as empty", "Please, fill in a quiz name", "Ok");
            }
        }

        // Custom highlight when tabbed on a list item
        // dit zorgt ervoor dat als men op een list item klikt, dat deze niet oranje wordt, en dat als je er op drukt deze ge-un-select wordt
        private void AnswerListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            // Deselect the item.
            if (sender is ListView lv) lv.SelectedItem = null;
        }

        // als op een radio button geklikt wordt, wordt deze doorgegeven aan een functie in de viewmodel
        public void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            cqpVM.RadioCheckedChanged(sender, e);
        }
    }
}