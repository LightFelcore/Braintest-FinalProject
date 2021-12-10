using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarinformsproject.Model
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public User()
        {

        }

        public override string ToString()
        {
            return "Id: " + Id + ", Username: " + Username + ", Password: " + Password;
        }
    }
}
