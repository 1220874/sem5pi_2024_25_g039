namespace Domain.Users
{
    public class UserDto
    {
        // public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public UserDto(string username, string role, string email)
        {
            Username = username;
            Role = role;
            Email = email;
        }
    }
}
