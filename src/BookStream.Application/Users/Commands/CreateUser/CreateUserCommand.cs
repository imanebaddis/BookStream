

using System;
using BookStream.Domain.Common.ResultPattern;
using BookStream.Application.User.Commands.CreateUser;

using BookStream.Domain.Entities; 
namespace BookStream.Application.Users.Commands.CreateUser

{
        public abstract class CreateUserCommand:IRequest<Guid>
    {
        public required string Name { get; init; }
        public required string Email { get; init; }

        public required string Password { get; init; }

        public required  string Username { get; init;}

        public required  string Role { get; init;}

 
    }
}






//USING System;
//using BookSrem.Domain.Common.ResultPattern;
//using BookStream.Domain.Common.Commands.CreateUser