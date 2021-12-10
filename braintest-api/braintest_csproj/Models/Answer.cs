using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public String QuizAnswer {get; set;}

    }
}