using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xamarinformsproject.Model;

namespace xamarinformsproject.Services
{
    public class APIDataStore: IDataStore
    {
        // Http Client module / make requests
        private HttpClient http = new HttpClient();

        public APIDataStore()
        {
            
        }

        // Add Quiz To DB
        public async Task<bool> AddQuizAsync(Quiz q)
        {
            var json = JsonConvert.SerializeObject(q, Formatting.Indented, new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects // dit is een optie die ik heb moeten aangezien quiz een complex json formaat heeft
            });
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // maakt een json object aan met al mijn data

            var res = await http.PostAsync("http://10.0.2.2:8000/api/quiz", stringContent); // post request om een quiz object door te sturen naar de databank


            return await Task.FromResult(res.IsSuccessStatusCode); // terugsturen van successcode, als alles oke is wordt 200 (GET) of 201 (INSERT) teruggestuurd anders een 400 code
        }

        public async Task<List<Quiz>> GetAllQuizAsync()
        {
            String response = await http.GetStringAsync("http://10.0.2.2:8000/api/quiz"); // get request om alle quizzes te verkrijgen van de databank

            return JsonConvert.DeserializeObject<List<Quiz>>(response); // terugsturen van successcode, als alles oke is wordt 200 (GET) of 201 (INSERT) teruggestuurd anders een 400 code
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            String response = await http.GetStringAsync("http://10.0.2.2:8000/api/user"); 

            return JsonConvert.DeserializeObject<List<User>>(response); // terugsturen van successcode, als alles oke is wordt 200 (GET) of 201 (INSERT) teruggestuurd anders een 400 code
        }

        public async Task<bool> AddUserAsync(User u)
        {
            var json = JsonConvert.SerializeObject(u); // serialise new user
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var res = await http.PostAsync("http://10.0.2.2:8000/api/user", stringContent);

            return await Task.FromResult(res.IsSuccessStatusCode); // terugsturen van successcode, als alles oke is wordt 200 (GET) of 201 (INSERT) teruggestuurd anders een 400 code
        }


        // function that checks wheter a user with given username and password do exists in the database or not. If user exists, this user will be returned, otherwise null
        public async Task<User> checkAuthentication(String usernameInput, String passwordInput)
        {
            User usr = new List<User>(await GetAllUserAsync())
                .Where(u => u.Username.Equals(usernameInput) && u.Password.Equals(passwordInput)).FirstOrDefault();
            return usr != null ? usr : null;
        }


    }
}
