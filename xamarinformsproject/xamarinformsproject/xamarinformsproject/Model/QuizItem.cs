using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinformsproject.Model
{

    // Elke quiz bevat een reeks van vragen met bijhorende verschillende mogelijke antwoorden
    public class QuizItem
    {
        [JsonIgnore]
        public static int QuizItemId { get; set; } // statische QuizItemId
        [JsonIgnore]
        public int Id { get; set; } // QuizId
        public String Question { get; set; } // input voor een bepaalde vraag
        public String Answer { get; set; } // juiste antwoord op een bepaalde vraag
    
        public List<Answer> Answers { get; set; } = new List<Answer>(); // alle mogelijke antwoorden waaruit een gebruiker kan kiezen


        [JsonIgnore]
        public String AllAnswersStr { get; set; } // custom string die alle mogelijke antwoorden antwoorden op een bepaalde vraag bijhoudt.

        public QuizItem() {}

        public QuizItem(String _question, String _answer, List<Answer> _answers)
        {
            Id = ++QuizItemId;
            Question = _question;
            Answer = _answer;
            Answers = _answers;

            // Aanmaken van de custom string, voor alle mogelijk antwoorden voor een bepaalde vraag
            for(int i = 0; i < Answers.Count; i++)
            {
                // laatste antwoord moet geen komma hebben
                if (i < Answers.Count - 1)
                {
                    AllAnswersStr += Answers[i].QuizAnswer + ", ";
                } else
                {
                    AllAnswersStr += Answers[i].QuizAnswer;
                }
            }

        }

        public override string ToString()
        {
            return " Id: " + Id + ", Question: " + Question + ", Answer: " + Answer + ", Answers:" + ListToString(Answers);
        }

        private String ListToString(List<Answer> list)
        {
            String str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str += " Answer " + (i+1) + ": " + list[i].QuizAnswer;
            }
            return str;
        }
    }
}
