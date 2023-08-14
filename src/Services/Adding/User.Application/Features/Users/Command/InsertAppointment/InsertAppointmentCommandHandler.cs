using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.InsertAppointment
{
    public class InsertAppointmentCommandHandler : IRequestHandler<InsertAppointmentCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public InsertAppointmentCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(InsertAppointmentCommand request, CancellationToken cancellationToken)
        {
            return await _userService.InsertAppointment(request);
        }
    }
}
