
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class QuizItem
    {
        public int Id { get; set; }
        public String Question { get; set; }

        public String Answer { get; set; }

        public List<Answer> Answers { get; set; }

    }
}