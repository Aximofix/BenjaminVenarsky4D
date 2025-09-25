namespace Projekt.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; } = -1;
        public string Password { get; set; } = string.Empty;
        public string Password1 { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Helpfull { get; set; } = string.Empty;
        public List<string>? Predmety { get; set; }
    }
}
