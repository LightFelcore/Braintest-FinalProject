using Xunit;
using xamarinformsproject.Services;
using xamarinformsproject.Model;
using System.Collections.Generic;

namespace UnitTests
{
    public class UnitTestQuiz
    {
        [Fact]
        public async void TestGetAllQuizAsync()
        {
            // Make an instance of the MockDataStore - Arrange
            MockDataStore md = new MockDataStore();
            Quiz mockQuiz = new Quiz()
            {
                Id = 1,
                Name = "General Quiz",
                QuizItems = new List<QuizItem>()
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
                QuizOwner = new User() { Id = 1, Username = "LightFelcore", Password = "aze123" }
            };

            // Act
            Quiz toCompareQuiz = await md.GetQuizById(1);

            // Assert
            Assert.Equal(mockQuiz.ToString(), toCompareQuiz.ToString());
        }

        [Fact]
        public async void TestAddQuizAsync()
        {
            // Arrange
            MockDataStore md = new MockDataStore();
            bool hasQuiz = false;
            Quiz mockQuiz = new Quiz()
            {
                Id = 1,
                Name = "General Quiz",
                QuizItems = new List<QuizItem>()
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
                QuizOwner = new User() { Id = 1, Username = "LightFelcore", Password = "aze123" }
            };

            // Act
            await md.AddQuizAsync(mockQuiz); // add a boiler quiz to QuizList in MockDataStore
            List<Quiz> AllQuizList = await md.GetAllQuizAsync(); // Get all quizes when adding one above
            foreach(Quiz item in AllQuizList)
            {
                if(item.Equals(mockQuiz))
                {
                    hasQuiz = true;
                    break;
                }
            }

            // Assert
            Assert.True(hasQuiz); // check is hasQuiz is True
        }
    }
}