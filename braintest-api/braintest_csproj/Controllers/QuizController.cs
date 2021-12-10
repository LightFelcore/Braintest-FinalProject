using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/quiz")]
    public class QuizController : ControllerBase
    {
        private readonly IRepo repo;
        private readonly IMapper map;

        public QuizController(IRepo _repo, IMapper _map)
        {
            repo = _repo;
            map = _map;
        }

        [HttpGet]
        public ActionResult GetAllQuiz()
        {
            return Ok(map.Map<IEnumerable<QuizReadDTO>>(repo.GetAllQuiz()));
        }

        [HttpGet("{id}")]
        public ActionResult GetQuizById(int id)
        {
            return Ok(map.Map<QuizReadDTO>(repo.GetQuizById(id)));
        }


        // toevoegen van een gebruiker
        // De gebruikers zullen zowieso al bestaan in de databank aangezien je geen quiz kan maken als je nog niet bent ingelogd.
        // Een gebruiker kan meerdere quizes toevoegen. Wanneer een quiz object aangemaakt wordt, werd ook een gebruiker aangemaakt gelinkt met deze gebruiker.
        // deze link tussen gebruiker en quiz moet er zijn.
        // Als de gebruiker al bestaat in de databank en deze maakt een nieuwe quiz aan, moet het id van de bestaande gebruiker gelinkt worden met de quiz. Er moet dus geen nieuwe gebruiker aangemaakt worden (geen dubbele data)
        [HttpPost]
        public ActionResult AddQuiz(QuizWriteDTO q)
        {
            var quiz = map.Map<Quiz>(q);

            User u = repo.getUser(q.QuizOwner.Username); // ingelogde gebruiker

            if(u != null){
                quiz.QuizOwner = u; // 

                repo.AddQuiz(quiz);
                repo.SaveChanges();

                return Ok(quiz);
            } else {
                return NotFound("User not found");
            }

            
        }
    }
}