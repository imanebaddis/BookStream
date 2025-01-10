namespace BookStream.Application.Subscription.Dtos
{//<summary>
  // Subscription 
  //</summary>
  public class SubscriptionDto
  {
        // <summary>
        /// The unique identifier for the Subscription
        /// </summary>
       public Guid id {get; set; }


       public required string Name { get; set;}

            /// <summary>
        /// The status of the category
        /// </summary>
        public bool IsActive { get; set; }

  }


}