namespace BookStream.Domain.Users.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Hash della password
        public string Role { get; set; } // Esempio: "Reader", "Author", "Admin"
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; } = true;

        // Relazioni con altre entità (opzionali)
        public List<string> FavoriteBooks { get; set; } = new();
        public List<string> ReadingHistory { get; set; } = new();
    }
}
