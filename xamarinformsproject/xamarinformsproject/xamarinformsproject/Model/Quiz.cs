using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using xamarinformsproject.ViewModel;

namespace xamarinformsproject.Model
{
    public class Quiz
    {
        [JsonIgnore]
        public int Id { get; set; } // id van de quiz
        public String Name { get; set; } // naam van de quiz
        public User QuizOwner { get; set; } // owner die dee quiz aanmaakte

        public List<QuizItem> QuizItems { get; set; } = new List<QuizItem>(); // een quiz bevat meerdere vragen met bijhorende antwoorden

        
        public Quiz()
        {
            Id++;
        }

        // for debugging
        public override string ToString()
        {
            return "Id: " + Id + ", Quiz Name: " + Name + ", QuizOwner: " + QuizOwner.ToString() + ", QuizItems: " + ListToString(QuizItems);
        }

        // omvormen van een list naar een string. Deze functie wordt opgeroepen in de ToString hierboven
        private string ListToString(List<QuizItem> quizItemsList)
        {
            String str = "";
            for(int i = 0; i < quizItemsList.Count; i++)
            {
                str += quizItemsList[i].ToString();
            }
            return str;

        }
    }
}
