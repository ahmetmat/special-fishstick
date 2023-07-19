namespace DTO
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class userDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public int Yas { get; set; }
        public string Roles { get; set; }
    }
}

