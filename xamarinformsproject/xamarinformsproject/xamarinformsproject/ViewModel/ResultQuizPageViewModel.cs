using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using xamarinformsproject.Model;

namespace xamarinformsproject.ViewModel
{
   
    public class ResultQuizPageViewModel
    {
        public Quiz CurrentQuiz { get; set; } // huidige quiz

        public List<String> UserAnswers{ get; set; } = new List<String>(); // lijst van alle antwoorden van de gebruiker
        public List<String> CorrectAnswers { get; set; } = new List<String>(); // lijst van alle juiste antwoorden

        // dit is een collection van tuples<string, string>. De reden dat ik dit gebruik is om op eenvoudige manier het antwoord van de gebruiker weer te geven samen met het juiste antwoord
        // een tuple bestaan uit (gebruiker antwoord, juiste antwoord)
        public ObservableCollection<Tuple<String, String>> ResultCollection { get; set; } 


        public int QuizScore { get; set; }
        public String QuizScoreColor { get; set; }
        public String AnswerQuizColor { get; set; }
        public String ElapsedTime { get; set; }

        public Command StartNewQuizCommand { get; set; }

        public ResultQuizPageViewModel(Quiz _currentQuiz, List<string> _userAnswers, String _elaspedTime)
        {

            CurrentQuiz = _currentQuiz;
            ElapsedTime = _elaspedTime;

            // opslagen van de gebruikers antwoorden
            foreach(var userAnswer in _userAnswers)
            {
                UserAnswers.Add(userAnswer);
            }
            // opslagen van de juiste antwoorden
            foreach(var item in CurrentQuiz.QuizItems)
            {
                CorrectAnswers.Add(item.Answer);
            }

            CreateResultCollection(); // opslagen van de juiste antwoorden en de gebruikers antwoorden in een colelction van tuples
            ProcessQuizResults(); // Calculate and preview correct colors

            StartNewQuizCommand = new Command(() => App.Current.MainPage.Navigation.PopToRootAsync());
        }

        private void CreateResultCollection()
        {
            ResultCollection = new ObservableCollection<Tuple<String,String>>();   
            for (int i = 0; i < UserAnswers.Count; i++)
            {
                ResultCollection.Add(new Tuple<string, string>(UserAnswers[i], CorrectAnswers[i]));
            }
        }

        // bepalen of een vraag correct beantwoord is geweest
        private void ProcessQuizResults()
        {
            int correct_answers = 0;
            for(int i = 0; i < UserAnswers.Count; i++)
            {
                if(UserAnswers[i].Equals(CorrectAnswers[i]))
                {
                    correct_answers++; // wordt gedaan om de score te kunnen bepalen van de gebruiker
                } 
            }

            QuizScore = (int)((double)correct_answers/UserAnswers.Count*100);

            if(QuizScore >= 50)
            {
                QuizScoreColor = "LightGreen";
            } else
            {
                QuizScoreColor = "LightCoral";
            }
        }
    }
}
