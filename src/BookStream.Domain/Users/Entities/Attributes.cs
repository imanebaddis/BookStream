using Supabase.Postgrest.Attributes;

namespace BookStream.Domain.Users.Entities
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}