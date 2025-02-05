namespace BookStream.Web.Blacklist
{
    public class BlacklistDTO
    {
        public int UserId { get; set; }
        public string Reason { get; set; }
        public DateTime AddedDate { get; set; }
    }
}