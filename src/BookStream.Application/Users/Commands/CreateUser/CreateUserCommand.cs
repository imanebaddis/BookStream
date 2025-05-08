using MediatR;

namespace BookStream.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}