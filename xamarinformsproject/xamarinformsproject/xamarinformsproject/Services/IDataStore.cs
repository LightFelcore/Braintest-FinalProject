using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarinformsproject.Model;

namespace xamarinformsproject.Services
{
    public interface IDataStore
    {
        Task<bool> AddQuizAsync(Quiz q);
        Task<bool> AddUserAsync(User u);

        Task<List<Quiz>> GetAllQuizAsync();

        Task<List<User>> GetAllUserAsync();

        Task<User> checkAuthentication(String usernameInput, String passwordInput);
    }
}
