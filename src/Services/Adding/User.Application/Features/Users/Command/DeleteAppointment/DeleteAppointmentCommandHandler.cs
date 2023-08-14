using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public DeleteAppointmentCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteAppointment(request);
        }
    }
}
