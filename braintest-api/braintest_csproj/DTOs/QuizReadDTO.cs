using webapi.Models;

namespace webapi.DTOs
{
    public class QuizReadDTO
    {
        public int id { get; set; }
        public String name { get; set; }
        public List<QuizItem> QuizItems { get; set; }
        public User QuizOwner { get; set; }
    }
}