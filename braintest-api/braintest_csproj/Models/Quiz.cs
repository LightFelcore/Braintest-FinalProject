using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<QuizItem> QuizItems { get; set; }
        public User QuizOwner { get; set; }

    }
}