namespace BookStream.Domain.Books.Exceptions
{
    /// <summary>
    /// Invalid category exception
    /// </summary> <summary>
    /// 
    /// </summary>
    public class InvalidCategoryException:Exception
    {
        public InvalidCategoryException(string message):base(message)
        {   
        }

        public InvalidCategoryException(string message, Exception innerException):base(message, innerException)
        {           
        }
    }
}