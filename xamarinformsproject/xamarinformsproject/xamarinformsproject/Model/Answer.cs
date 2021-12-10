using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using xamarinformsproject.ViewModel;

namespace xamarinformsproject.Model
{
    public class Answer : BaseViewModel
    {
        [JsonIgnore]
        public static int AnswerId { get; set; } // statische answer id

        [JsonIgnore]
        public int Id { get; set; } // id van een answer

        public String QuizAnswer { get; set; } // Answer input

        [JsonIgnore]
        public String AnswerPlaceholder { get; set; } // wordt gebruikt om een custom placeholder te maken, gebonden aan de placeholder van een antwoord entry in .xaml

        // Dit is een boolean dat gebruikt wordt om na te gaan welke answer werd aangedrukt bij het toevoegen van antwoorden voor een bepaalde vraag in een quiz
        [JsonIgnore]
        public bool isRadioChecked = true;
        [JsonIgnore]
        public bool IsRadioChecked 
        { 
            get { return isRadioChecked; }
            set { isRadioChecked = value; OnPropertyChanged(); }
        }

        public Answer() { } // lege constructor is nodig voor het opvragen van data via de api in JSON formaat

        public Answer(bool IsGeneratedAnswer, String _answerInput = "") 
        {
            Id = ++AnswerId;
            QuizAnswer = _answerInput;
            AnswerPlaceholder = ToString(); // deze property wordt gebruikt om een custom placeholder te maken als mijn answer entry leeg is
            
            // Bij het aanmaken van een nieuwe answer, wordt automatisch de eerste radio button aangevingt, de volgende worden niet aangevingt.
            if(AnswerId == 1)
            {
                IsRadioChecked = true;
            } else
            {
                IsRadioChecked = false;
            }

        }

        // ToString wordt gebruikt om een custom placeholder te maken als de entry voor een answer leeg is, zie lijn 40
        public override string ToString()
        {
            return "Answer: " + Id;
        }
    }
}
