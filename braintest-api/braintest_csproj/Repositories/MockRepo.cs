using webapi.Models;

namespace webapi.Repositories
{
    public class MockRepo : IRepo
    {
        private List<Quiz> QuizList = new List<Quiz>();

        public MockRepo()
        {
            /* QuizList.Add(new Quiz() { 
                QuizId = 1,
                Name="General Quiz", 
                QuizItems= new List<QuizItem>() 
                { 
                    new QuizItem(){QuizItemId = 1, Question = "What is your favourite color?", Answer = "Yellow", Answers = new List<Answer>() { 
                        new Answer(){Id = 1, QuizAnswer = "Yellow"}, 
                        new Answer(){Id =2, QuizAnswer = "Black"}, 
                        new Answer(){Id = 3, QuizAnswer = "Purple"}
                    }},
                    new QuizItem(){QuizItemId = 2, Question = "How many pets does homer have?", Answer = "3", Answers = new List<Answer>() { 
                        new Answer(){Id = 1, QuizAnswer = "1"}, 
                        new Answer(){Id = 2, QuizAnswer = "3"}, 
                        new Answer(){Id = 3, QuizAnswer = "2"} 
                    }},
                    new QuizItem(){QuizItemId = 3, Question = "How much is 1 + 1?", Answer = "2", Answers = new List<Answer>() {
                         new Answer(){Id = 1, QuizAnswer = "5"}, 
                         new Answer(){Id = 2, QuizAnswer = "2"}, 
                         new Answer(){Id = 3, QuizAnswer = "1"} 
                    }},
                    new QuizItem(){QuizItemId = 4, Question = "Who is Big Shack?", Answer = "The one and only", Answers = new List<Answer>() { 
                        new Answer(){Id = 1, QuizAnswer = "Man's not hot"}, 
                        new Answer(){Id = 2, QuizAnswer = "The one and only"},
                        new Answer(){Id = 3, QuizAnswer = "Nobody"}
                    }}

                }, 
                QuizOwener = new User(){ Id = 1, Username = "LightFelcore", Password = "aze123", QuizId = 1 }
            });
            QuizList.Add(new Quiz() { 
                QuizId = 2,
                Name="C++ Quiz", 
                QuizItems= new List<QuizItem>() 
                { 
                    new QuizItem(){QuizItemId = 1, Question = "What is the value of boolean true?", Answer = "1", Answers = new List<Answer>() {
                         new Answer(){Id = 1, QuizAnswer = "0"}, 
                         new Answer(){Id = 2, QuizAnswer = "-1"}, 
                         new Answer(){Id = 3, QuizAnswer = "1"}
                    }},
                    new QuizItem(){QuizItemId = 2, Question = "What is C++", Answer = "Programming language", Answers = new List<Answer>() { 
                        new Answer(){Id = 1, QuizAnswer = "Programming language"},
                        new Answer(){Id = 2, QuizAnswer = "Front-end framework"},
                        new Answer(){Id = 3, QuizAnswer = "Back-end framework"}
                    }},
                    new QuizItem(){QuizItemId = 3, Question = "C++ a directive from the C-language", Answer = "True", Answers = new List<Answer>() { 
                        new Answer(){Id = 1, QuizAnswer = "False"}, 
                        new Answer(){Id = 2, QuizAnswer = "True"}
                    }}

                }, 
                QuizOwener = new User(){ Id = 2, Username = "DarkFelcore", Password = "aze456", QuizId = 2 }
            }); */
        }

        public void AddQuiz(Quiz q)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User u)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Quiz> GetAllQuiz()
        {
            return QuizList;
        }

        public IEnumerable<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Quiz GetQuizById(int id)
        {
            Quiz quiz = QuizList.FirstOrDefault<Quiz>(q => q.Id == id);
            return quiz;
        }

        public User getUser(string username)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}