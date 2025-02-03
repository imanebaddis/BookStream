namespace BookStream.BookStream.src.BookStream.Application.Blacklist.Dtos;
{
    public class BlacklistDTO
    {
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime AddedDate { get; set; }
    }
}