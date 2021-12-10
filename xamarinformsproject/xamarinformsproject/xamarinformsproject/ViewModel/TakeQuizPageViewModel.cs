using System;
using System.Timers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using xamarinformsproject.Model;

namespace xamarinformsproject.ViewModel
{
    public class TakeQuizPageViewModel: BaseViewModel
    {
        public Quiz CurrentQuiz { get; set; } // huidige quiz

        private QuizItem currentQuizItem = null;
        public QuizItem CurrentQuizItem {  // huidige quiz item (bestaande uit een vraag met meerdere antwoorden en het juiste antwoord)
            get { return currentQuizItem; }
            set { currentQuizItem = value; OnPropertyChanged(); }
        }   

        public DateTime StartQuizTime { get; set; } // date  time object dat gebruikt wordt om te bepalen hoe lang de quiz heeft geduurd

        public int index { get; set; } = 0;


        // List for previewing answers
        public ObservableCollection<TakeQuizAnswer> PreviewAnswers { get; set; } = new ObservableCollection<TakeQuizAnswer>(); // colelction om de mogelijke antwoorden op een bepaalde vraag op te slagen

        // Store users answers for a specific quiz
        public List<String> UserAnswers { get; set; } = new List<String>();

        // When Quiz is stopped
        public Command AbortQuizCommand { get; set; }

        // When user clicks a answer button during the quiz
        public Command AnswerClickedCommand { get; set; }


        public TakeQuizPageViewModel(Quiz q)
        {
            // Start een timer die om de seconde loopt
            StartQuizTime = DateTime.Now;
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Start();

            // Set the passed Quiz object, in order that we can use it on the TakeQuizPage
            CurrentQuiz = q;
            CurrentQuizItem = CurrentQuiz.QuizItems[index];

            // Preview the first question when the quiz starts
            foreach (var item in CurrentQuiz.QuizItems[index].Answers)
            {
                PreviewAnswers.Add(new TakeQuizAnswer() { PreviewAnswer = item.QuizAnswer });
            }

            // als een gebruiker een antwoord aanklikt
            AnswerClickedCommand = new Command(OnAnswerClicked);

            // als de quiz gestopt wordt
            AbortQuizCommand = new Command(() => App.Current.MainPage.Navigation.PopAsync());
        }


        // Method for starting a quiz
        public void OnAnswerClicked(object sender)
        {
            index++;
            // Store user answers
            String answer = sender as String;
            UserAnswers.Add(answer);

            // blijf een volgende vraag tonen tot er geen meer zijn
            if (index < CurrentQuiz.QuizItems.Count)
            {
                PreviewAnswers.Clear();

                // Show next question
                CurrentQuizItem = CurrentQuiz.QuizItems[index];

                // Preview the first question when the quiz starts
                foreach (var item in CurrentQuiz.QuizItems[index].Answers)
                {
                    PreviewAnswers.Add(new TakeQuizAnswer() { PreviewAnswer = item.QuizAnswer });
                }

            } else
            {
                // als alle vragen beantwoord zijn, wordt de quiz tijd bepaald en wordt de huidige quiz, gebruikers antwoorden en de tijd doorgegeven aan de resultaat pagina
                TimeSpan timeDiff = DateTime.Now - StartQuizTime;
                string readableDiff = string.Format("{0:D2} hrs, {1:D2} mins, {2:D2} secs", timeDiff.Hours, timeDiff.Minutes, timeDiff.Seconds);
                
                App.Current.MainPage.Navigation.PushAsync(new ResultQuizPage(CurrentQuiz, UserAnswers, readableDiff));
            }

        }

        // called from code behind
        // als de quiz wordt gestart moet de eerste vraag getoond worden
        public void OnAppearing()
        {
            PreviewAnswers.Clear();
            UserAnswers.Clear();
            index = 0;

            CurrentQuizItem = CurrentQuiz.QuizItems[index];

            // Preview the first question when the quiz starts
            foreach (var item in CurrentQuiz.QuizItems[index].Answers)
            {
                PreviewAnswers.Add(new TakeQuizAnswer() { PreviewAnswer = item.QuizAnswer });
            }
        }
    }
}
