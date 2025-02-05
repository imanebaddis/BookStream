namespace BookStream.BookStream.src.BookStream.Application.Blacklist.Dtos
{
    public class BlacklistDto
    {
        public BlacklistDto(int userId, string reason, DateTime addedDate)
        {
            UserId = userId;
            Reason = reason;
            AddedDate = addedDate;
        }

        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime AddedDate { get; set; }
    }
}