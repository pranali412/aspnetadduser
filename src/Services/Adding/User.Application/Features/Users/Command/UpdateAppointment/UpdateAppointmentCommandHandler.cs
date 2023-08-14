using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public UpdateAppointmentCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateAppointment(request);
        }
    }
}
