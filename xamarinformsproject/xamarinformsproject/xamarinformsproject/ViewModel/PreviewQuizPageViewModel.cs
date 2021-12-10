using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using xamarinformsproject.Model;

namespace xamarinformsproject.ViewModel
{
    public class PreviewQuizPageViewModel : BaseViewModel
    {
        public Quiz QuizObj { get; set; } // quiz dat afgelgd wordt

        public Command FinalizeQuizCommand { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command ToCreateQuizPage { get; set; }

        public PreviewQuizPageViewModel(Quiz q)
        {
            FinalizeQuizCommand = new Command(OnFinalizeQuizClick);
            LoadItemsCommand = new Command(LoadItems);
            ToCreateQuizPage = new Command(() =>
            {
                App.Current.MainPage.Navigation.PopAsync(); 
            });

            QuizObj = q;
        }


        // toevoegen van de nieuwe quiz aan de hand van de api
        private async void OnFinalizeQuizClick()
        {
            if (await DataStore.AddQuizAsync(QuizObj)) 
            {
                await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            } else
            {
                await App.Current.MainPage.DisplayAlert("Failed to add a quiz", "Please, try again at a later moment", "OK");
            }
            
        }
    }
}
