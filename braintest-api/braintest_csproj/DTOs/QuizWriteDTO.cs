using webapi.Models;

namespace webapi.DTOs
{
    public class QuizWriteDTO
    {
        public String Name { get; set; }
        public List<QuizItem> QuizItems { get; set; }
        public User QuizOwner { get; set; }
    }
}