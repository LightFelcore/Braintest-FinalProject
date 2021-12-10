using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using xamarinformsproject.Model;

namespace xamarinformsproject.ViewModel
{
    public class CreateQuizPageViewModel : BaseViewModel
    {
        public ObservableCollection<Answer> AnswerCollection { get; set; } = new ObservableCollection<Answer>(); // ObservableCollection die dient om alle mogelijke antwoorden voor een bepaalde vraag uit een quiz op te slagen
        
        public Answer SelectedAnswer { get; set; } // Gebruiker kan een radio button aanvinken bij een antwoord

        public String CorrectAnswer { get; set; } // bevat het juiste antwoord op een bepaalde vraag

        public String QuizName { get; set; } // naam van de quiz

        private String quizQuestion = "";
        public String QuizQuestion // quiz vraag
        {
            get { return quizQuestion; }
            set { quizQuestion = value; OnPropertyChanged(); }
        }

        public int listViewHeight = 50; // dit is een custom hoogte van de listview waarin de antwoorden op een bepaalde vraag zich bevinden, start bij 50 hoogte
        public int ListViewHeight
        {
            get{return listViewHeight;}
            set{ listViewHeight = value; OnPropertyChanged(); }
        }

        Quiz QuizObj { get; set; }

        public Command AddItemToQuizCommand { get; set; } 
        public Command AddQuestionCommand { get; set; }
        public Command PreviewQuizCommand { get; set; }
        public Command ToNextStepCommand { get; set; }

        public CreateQuizPageViewModel()
        {
            Answer.AnswerId = 0;
            QuizItem.QuizItemId = 0;

            AddItemToQuizCommand = new Command(OnAddItemToQuizClick); // als een quiz item wordt toegevoegd aan een quiz
            AddQuestionCommand = new Command(OnAddQuestionClick); // als een extra anbtwoord op een vraag moet toegevoegd worden
            PreviewQuizCommand = new Command(OnPreviewQuizClick); // om een preview te krijgen van alle vragen en antwoorden die al reeds werden toegevoegd
            ToNextStepCommand = new Command(() => QuizObj = new Quiz() { Name = QuizName.ToUpper(), QuizOwner = LoggedInUser }); // wanneer de naam van de quiz werd ingevuld, wordt een quiz object aangemaakt die de naam van de quiz en de ingelogde gebruiker opslaagd in een quizobject, later worden de quizitems in de applicatie hieraan toegevoegd

            AnswerCollection.Add(new Answer(true)); // genereert standaard al een antwoord voor een bepaalde vraag

        }

        // Als een quizitem wordt aangemaakt worden de entries eerst getrimt en vervolgens gevalideerd
        public void OnAddItemToQuizClick()
        {
            TrimAllEntries();
            ValidateEntries();
        }

        // When user wants to add a question to the Quiz - in the beginning there is only one answer displayed on the screen
        async public void OnAddQuestionClick()
        {
            // er kunnen maximaal 5 antwoorden per vraag zijn
            if(AnswerCollection.Count < 5)
            {
                ListViewHeight += 50; // add height to the listview
                AnswerCollection.Add(new Answer(true));
            } else
            {
                await App.Current.MainPage.DisplayAlert("Maximum Answers", "You can add maxmim 5 answers per question", "OK");
            }
        }


        // deze functie wordt automatsich opgeroepen als er zich een CheckedChangedEvent optreed. Met andere woorden als men een andere radio button aanvinkt.
        public void RadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Enkel de nieuwe radio button die wordt aangedrukt, niet degene die ge-unchecked wordt
            if(e.Value)
            {
                RadioButton rb = (RadioButton)sender; // neem de aangedrukt radio button binnen door het sender object te gebruiken
                foreach (Answer answer in AnswerCollection)
                {
                    // check welke radio button id match met het id van de vraag, als er een match is, wordt dat antwoord opgeslagen in CorrectAnswer
                    if (rb.Content.ToString() == answer.Id.ToString())
                    {
                        CorrectAnswer = answer.QuizAnswer;
                        break;
                    }
                }
            }
        }

        // als men klikt op de button om een overzicht te krijgen van alle reeds toegevoegde vragen en antwoorden
        public void OnPreviewQuizClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new PreviewQuizPage(QuizObj));
        }



        //Validate if minimum requested entries are filled in
        async public void ValidateEntries()
        {
            bool allFilledUp = true;

            if(string.IsNullOrEmpty(QuizQuestion) && string.IsNullOrWhiteSpace(QuizQuestion))
            {
                await App.Current.MainPage.DisplayAlert("Question is empty", "Please, fill in your question", "OK");
                allFilledUp = false;
            } else
            {
                foreach (Answer a in AnswerCollection)
                {
                    if (string.IsNullOrEmpty(a.QuizAnswer) && string.IsNullOrWhiteSpace(a.QuizAnswer))
                    {
                        await App.Current.MainPage.DisplayAlert("Answers are empty", "Please, fill in all your the answers", "OK");
                        allFilledUp = false;
                        break;
                    } 
                }
            }
            if(allFilledUp)
            {
                // Create Quiz item and store it in a global Quiz Collection
                SaveItemToQuizCollection();
                // Everything is filled up correctly
                ClearAllEntries();
            }
        }

        public void SaveItemToQuizCollection()
        {
            // If RadioCheckedChanged hasn't been executed
            if (CorrectAnswer.Equals(""))
            {
                CorrectAnswer = AnswerCollection[0].QuizAnswer;
            }

            List<Answer> AnswerList = new List<Answer>(AnswerCollection);
            
            
            // Create a Quiz Item
            QuizItem qa = new QuizItem(QuizQuestion, CorrectAnswer, AnswerList);
            QuizObj.QuizItems.Add(qa);
        }

        // Trim all inputs when Quiz is created
        public void TrimAllEntries()
        {
            QuizName = QuizName.Trim();
            foreach (Answer a in AnswerCollection)
            {
                a.QuizAnswer = a.QuizAnswer.Trim();
            }

        }

        // Clear all entries for next coming question/answers
        public void ClearAllEntries()
        {
            QuizName = "";
            QuizQuestion = "";
            ListViewHeight = 50;

            // Zet de anwser id weer op 0, zodat als een nieuwe wordt aangemaakt, het id op 1 staat, waardoor dat de radio button bij het eerste input veld aangvinkt wordt
            Answer.AnswerId = 0;

            AnswerCollection.Clear(); // clear alle antwoorden van voorgaande vraag
            AnswerCollection.Add(new Answer(true)); // voeg een nieuwe toe, zodat bioj de volgende vraag weer standaard 1 antwoord staat
            
        }


    }

}
