namespace BookStream.Domain.Books.ExceptionsInvalidUserException
{
    /// <summary>
    /// Invalid User exception
    /// </summary> <summary>
    /// 
    /// </summary>
    public class InvalidUserException:Exception
    {
        public InvalidUserException(string message):base(message)
        {   
        }

        public InvalidUserException(string message, Exception innerException):base(message, innerException)
        {           
        }
    }
}