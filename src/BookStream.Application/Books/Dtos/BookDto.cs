/*namespace BookStream.Application.Books.Dtos
{
    public class BookDto;
    //<summary>
    //BookId
    // </summary>
    public Guid Id { get; set; }

    //<summary>
    //Title
    // </summary>
   public required string Title { get; set;}

   // //<summary>
    //Author
    // </summary>
    public required string Author { get; set; }

    //<summary>
    //CategoryId
    // </summary>
    public required Guid CategoryId { get; set;}


    //<summary>
    //ISBN
    // </summary>
    public required string ISBN { get; set;}


    //<summary>
    //Description
    // </summary>
    public required string Description { get; set;}

    //<summary>
    //publishedDate
    // </summary>
    public required DateTime? PublishedDate { get; set;}

    //<summary>
    //CoverImageUrl
    // </summary>
    public string? CoverImageUrl {get; set;}

    //<summary>
    // Create at date
    // </summary>
    public DateTime CreateDat { get; set; }
 
    /// <summary>
    /// Price
    /// </summary>
    public decimal Price { get; set; }
}*/

namespace BookStream.Application.Books.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class UpdateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
