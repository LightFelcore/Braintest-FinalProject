using webapi.Models;

namespace webapi.Repositories
{
    // definitie voor alle functie die er gebruikt worden - model
    public interface IRepo
    {
        IEnumerable<Quiz> GetAllQuiz();
        Quiz GetQuizById(int id);

        IEnumerable<User> GetAllUser();

        void AddQuiz(Quiz q);
        void AddUser(User u);

        User getUser(String username);

        void SaveChanges();
    }
}