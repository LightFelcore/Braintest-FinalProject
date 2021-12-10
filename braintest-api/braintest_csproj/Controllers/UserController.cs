using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Models;
using webapi.Repositories;

namespace webapi.Contexts
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IRepo repo; // gebruik maken van de repo om access te hebben tot de functies die erin gedefinieerd staan
        private readonly IMapper map; // mapper om te kunnen mappen van een model naar een readDTO of van een writeDTO naar een model
        public UserController(IRepo _repo, IMapper _map)
        {
            repo = _repo;
            map = _map;
        }

        [HttpGet]
        public ActionResult GetAllUser()
        {
            return Ok(map.Map<IEnumerable<UserReadDTO>>(repo.GetAllUser()));
        }

        // toevoegen van een gebruiker aan de databank, een gebruiker zal niet kunnen worden toegevoegd als de username al bestaat
        [HttpPost]
        public ActionResult AddUser(UserWriteDTO u)
        {
            var LoggedInUser = map.Map<User>(u);

            var DbUserMatch = repo.getUser(LoggedInUser.Username);

            if(DbUserMatch == null)
            {
                repo.AddUser(LoggedInUser);
                repo.SaveChanges();
                return Ok(LoggedInUser);
            } else {
                return NotFound("User already present in db");
            }
        }
    }
}