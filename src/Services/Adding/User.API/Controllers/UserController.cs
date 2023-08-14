using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using User.Application.Features.Users.Command.DeleteRole;
using User.Application.Features.Users.Command.DeleteUser;
using User.Application.Features.Users.Command.InserRole;
using User.Application.Features.Users.Command.InsertUser;
using User.Application.Features.Users.Command.UpdateRole;
using User.Application.Features.Users.Command.UpdateUser;
using User.Application.Features.Users.Queries.GetUserList;
using User.Domain.ViewModel;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("Get")]
        [ProducesResponseType(typeof(IEnumerable<UserVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ResponseModel>> GetUserById(GetUserListQuerry query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult<ResponseModel>> InsertUser(InsertUserCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<ResponseModel>> UpdateUser(UpdateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult<ResponseModel>> DeleteUser(DeleteUserCommand command)
        {
            return await _mediator.Send(command);
        }
        //public async Task<ActionResult> DeleteUser(int id)
        //{
        //    var command = new DeleteUserCommand() { Id = id };
        //    await _mediator.Send(command);
        //    return NoContent();
        //}

        [HttpPost]
        [Route("InsertRole")]
        public async Task<ActionResult<ResponseModel>> InsertRole(InsertRoleCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        [Route("UpdateRole")]
        public async Task<ActionResult<ResponseModel>> UpdateRole(UpdateRoleCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete]
        [Route("DeleteRole")]

        public async Task<ActionResult<ResponseModel>> DeleteRoles(DeleteRoleCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
