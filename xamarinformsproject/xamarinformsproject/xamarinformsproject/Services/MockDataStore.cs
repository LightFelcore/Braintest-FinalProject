using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using xamarinformsproject.Model;

namespace xamarinformsproject.Services
{
    // This file is used for the Unit Testing. Only GetAllQuizes and AddQuizAsync are tested

    public class MockDataStore : IDataStore
    {
        public List<Quiz> QuizList { get; set; } = new List<Quiz>();

        public MockDataStore()
        {
            QuizList.Add(new Quiz() { 
                Id = 1,
                Name="General Quiz", 
                QuizItems= new List<QuizItem>() 
                { 
                    new QuizItem(){Id = 1, Question = "What is your favourite color?", Answer = "Yellow", Answers = new List<Answer>() { 
                        new Answer(false){Id = 1, QuizAnswer = "Yellow"}, 
                        new Answer(false){Id =2, QuizAnswer = "Black"}, 
                        new Answer(false){Id = 3, QuizAnswer = "Purple"}
                    }},
                    new QuizItem(){Id = 2, Question = "How many pets does homer have?", Answer = "3", Answers = new List<Answer>() { 
                        new Answer(false){Id = 1, QuizAnswer = "1"}, 
                        new Answer(false){Id = 2, QuizAnswer = "3"}, 
                        new Answer(false){Id = 3, QuizAnswer = "2"} 
                    }},
                    new QuizItem(){Id = 3, Question = "How much is 1 + 1?", Answer = "2", Answers = new List<Answer>() {
                         new Answer(false){Id = 1, QuizAnswer = "5"}, 
                         new Answer(false){Id = 2, QuizAnswer = "2"}, 
                         new Answer(false){Id = 3, QuizAnswer = "1"} 
                    }},
                    new QuizItem(){Id = 4, Question = "Who is Big Shack?", Answer = "The one and only", Answers = new List<Answer>() { 
                        new Answer(false){Id = 1, QuizAnswer = "Man's not hot"}, 
                        new Answer(false){Id = 2, QuizAnswer = "The one and only"},
                        new Answer(false){Id = 3, QuizAnswer = "Nobody"}
                    }}

                },
                QuizOwner = new User(){ Id = 1, Username = "LightFelcore", Password = "aze123" }
            });
            
        }

        // Unit Tested
        public Task<bool> AddQuizAsync(Quiz q)
        {
            QuizList.Add(q);

            return Task.FromResult(true);
        }

        public Task<bool> AddUserAsync(User u)
        {
            throw new NotImplementedException();
        }

        public Task<User> checkAuthentication(string usernameInput, string passwordInput)
        {
            throw new NotImplementedException();
        }

        // Unit Tested
        public Task<List<Quiz>> GetAllQuizAsync()
        {
            return Task.FromResult(QuizList);
        }

        public Task<List<User>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Quiz> GetQuizById(int id)
        {
            Quiz quiz = QuizList.FirstOrDefault<Quiz>(q => q.Id == id);
            return Task.FromResult(quiz);
        }
    }
}
