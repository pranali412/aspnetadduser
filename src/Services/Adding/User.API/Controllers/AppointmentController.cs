using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.Application.Features.Users.Command.DeleteAppointment;
using User.Application.Features.Users.Command.DeleteDepartment;
using User.Application.Features.Users.Command.InsertAppointment;
using User.Application.Features.Users.Command.InsertDepartment;
using User.Application.Features.Users.Command.UpdateAppointment;
using User.Application.Features.Users.Command.UpdateDepartment;
using User.Application.Features.Users.Queries.GetAppointmentList;
using User.Application.Features.Users.Queries.GetDrDropdownlist;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public AppointmentController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<ResponseModel>> GetAppointment(GetAppointmentListQuerry query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult<ResponseModel>> InsertAppointment(InsertAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<ResponseModel>> UpdateAppointment(UpdateAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("Delete")]

        public async Task<ActionResult<ResponseModel>> DeleteAppointment(DeleteAppointmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost]
        [Route("InsertDept")]
        public async Task<ActionResult<ResponseModel>> InsertDepartment(InsertDepartmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        [Route("UpdateDept")]
        public async Task<ActionResult<ResponseModel>> UpdateDepartment(UpdateDepartmentCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete]
        [Route("DeleteDept")]

        public async Task<ActionResult<ResponseModel>> DeleteDepartment(DeleteDepartmentCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpPost]
        [Route("GetDoctorList")]
        public async Task<ActionResult<ResponseModel>> GetDoctorList(GetDrDropdownlistQuerry query)
        {
            return await _userService.GetDoctorList(query);
        }

    }
}
