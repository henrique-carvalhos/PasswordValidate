using CQRS.Extensions;
using CQRS.Extensions.Interfaces;
using MediatR;
using PasswordValidate.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordValidate.Application.Commands
{
    public class PasswordCommandHandler : ICommandHandler<PasswordCommand, Password>
    {
        async Task<Result<Password>> IRequestHandler<PasswordCommand, Result<Password>>.Handle(PasswordCommand request, CancellationToken cancellationToken)
        {
            var password = new Password() { IsValid = true };

            return Result.Success(password);
        }
    }
}
