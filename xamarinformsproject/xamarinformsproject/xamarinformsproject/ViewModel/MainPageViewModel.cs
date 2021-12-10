using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarinformsproject.Model;

namespace xamarinformsproject.ViewModel
{
    internal class MainPageViewModel : BaseViewModel
    {
        // Data of a particular Quiz
        public ObservableCollection<Quiz> QuizData { get; set; } = new ObservableCollection<Quiz>();

        List<Quiz> EQuiz { get; set; }

        public bool NoQuizesFound { get; set; } = false;
        public bool ShowRefreshingView { get; set; } = true;

        // Command for loading the Quiz data
        public Command LoadItemsCommand { get; set; }
        
        // Command for creating a new Quiz
        public Command CreateQuizCommand { get; set; }

        // Als er op een quiz gedrukt wordt om deze af te leggen
        public Command QuizTappedCommand { get; set; }

        // Ctor
        public MainPageViewModel()
        {
            // Declaring a new command, giving the LoadItems to the delegate
            LoadItemsCommand = new Command(LoadItems);

            // Declaring a new command, giving the OnCreateNewQuizClick to the delegate
            CreateQuizCommand = new Command(OnCreateNewQuizClick);

            // When user select a quiz to start
            QuizTappedCommand = new Command<Quiz>(OnQuizTappedClick); // geef het quiz object door naar deze functie

        }

        // Quiz object wordt doorgegeven naar volgende pagina
        public void OnQuizTappedClick(Quiz tappedQuiz)
        {
            App.Current.MainPage.Navigation.PushAsync(new TakeQuizPage(tappedQuiz));
        }

        // Deze functie wordt opgevraagd in de OnAppearing vanuit de mainpage code-behind
        async public void LoadQuizData()
        {
            QuizData.Clear();

            EQuiz = await DataStore.GetAllQuizAsync(); // vraag alle quiz data op die in de databank staat

            if(EQuiz != null)
            {
                foreach (var item in EQuiz)
                {
                    QuizData.Add(item); // elke item in de databank wordt opgeslagen in een lokale observablecollection
                }

                // Als er geen quizes zijn, moet er een label te voorschijn komen, anders een lisjt van alle quizes
                if (QuizData.Count == 0)
                {
                    NoQuizesFound = true;
                    ShowRefreshingView = false;
                }
                else
                {
                    NoQuizesFound = false;
                    ShowRefreshingView = true;
                }
            } else
            {
                await App.Current.MainPage.DisplayAlert("Something went wrong", "Please, try again at a later moment", "OK");
            }
        }


        // Method called when user wants to create a new Quiz
        public void OnCreateNewQuizClick()
        {
            // Check wether a user is logged in or not. If not route
            // to the LoginPage, otherwise route to CreateQuizPage
            if(!IsLoggedIn)
            {
                App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            } else
            {
                App.Current.MainPage.Navigation.PushAsync(new CreateQuizPage());
            }
        }

    }
}
