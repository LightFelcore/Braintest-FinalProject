using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Contexts
{
    public class QuizContext : DbContext
    {
        /* Tabellen in de databank */
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizItem> QuizItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuizContext(DbContextOptions<QuizContext> opt) : base(opt)
        {

        }

    }
}