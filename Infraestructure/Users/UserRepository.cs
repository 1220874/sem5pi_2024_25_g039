using System.Collections.Generic;
using System.Linq;
using Domain.Users;

namespace Infraestructure.Users
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "doctor", Password = "123", Role = "Doctor" });
            users.Add(new User { Id = 2, Username = "patient", Password = "123", Role = "Patient" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}