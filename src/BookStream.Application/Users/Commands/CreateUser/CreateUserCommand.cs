using BookStream.Domain.Common.ResultPattern;
using BookStream.Application.User.Commands.CreateUser;

{
    public class CreateUserCommand:IRequest<Result<Guid>>
    {
        public required string Name { get; init; }
        
    }
}