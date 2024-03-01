using CQRS.Extensions.AspNetMVC;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PasswordValidate.Application.Commands;
using PasswordValidate.Core.Entities;
using System.Threading.Tasks;

namespace PasswordValidate.API.Controllers
{
    [Route("api/password")]
    public class PasswordController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PasswordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public async Task<IActionResult> PostPassword([FromBody] PasswordCommand command)
        {
            var result = await _mediator.Send(command);

            return result.AsActionResult<Password>();
        }
    }
}


