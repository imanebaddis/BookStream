namespace BookStream.Domain.Subscriptions.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Type { get; set; } // Mensile, Annuale
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
