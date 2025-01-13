using System;
using System.Threading;

using BookStream.Domain.Common.ResultPattern;
using BookStream.Application.User.Commands.LoginUserCommand;

using BookStream.Domain.Entities; 
public class LoginUserCommand : IRequest<Result<Guid>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
