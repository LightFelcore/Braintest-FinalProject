using Microsoft.EntityFrameworkCore;
using webapi.Contexts;
using webapi.Models;

namespace webapi.Repositories
{
    public class MysqlRepo : IRepo // implementeert alle functies uit de interface
    {
        private readonly QuizContext context; // context laat toe om de tabellen te accessen

        public MysqlRepo(QuizContext _context)
        {
            context = _context;
        }

        // toevoegen van een quiz aan de quiz tabel
        public void AddQuiz(Quiz q)
        {
            context.Quizzes.Add(q);
        }

        // teovoegen van een gebruiker een de user tabel
        public void AddUser(User u)
        {
            context.Users.Add(u);
        }

        // verkrijgen van alle quizes uit de quiz tabellen
        // omdat deze ook linken heeft naar andere tabellen moet link gebruikt worden om de andere tabellen te includen.
        public IEnumerable<Quiz> GetAllQuiz()
        {
            return context.Quizzes
                .Include(u => u.QuizOwner)
                .Include(qi => qi.QuizItems)
                    .ThenInclude(a => a.Answers).ToList();
        }

        // vergrijgen van alle gebruikers uit de user tabel
        public IEnumerable<User> GetAllUser()
        {
            return context.Users;
        }

        // een specifieke quiz verkrijgen op basis van id
        public Quiz GetQuizById(int id)
        {
            return context.Quizzes.FirstOrDefault<Quiz>(q => q.Id == id);
        }

        // een bepaalde gebruiker verkrijgen op username
        public User getUser(string username)
        {
            return context.Users.FirstOrDefault<User>(u => u.Username == username);
        }

        // Save changes op de veranderingen in de databank degelijk te verkrijgen.
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}