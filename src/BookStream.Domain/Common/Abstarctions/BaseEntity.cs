namespace BookStream.Domain.Common.Abstractions
{
    public class BaseEntity
    {
        /// <summary>
        /// The unique identifier for the entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The date and time the entity was created
        /// </summary>
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time the entity was last modified
        /// </summary> 
        public DateTimeOffset? ModifiedAt { get; set; }

        /// <summary>
        /// The user who created the entity
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// The user who last modified the entity
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}