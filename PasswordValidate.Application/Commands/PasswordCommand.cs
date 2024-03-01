using CQRS.Extensions.Interfaces;
using PasswordValidate.Core.Entities;

namespace PasswordValidate.Application.Commands
{
    public class PasswordCommand : ICommand<Password>
    {
        public string Password { get; set; }

    }
}
