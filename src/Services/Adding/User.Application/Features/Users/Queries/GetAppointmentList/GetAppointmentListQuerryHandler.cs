using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Queries.GetAppointmentList
{
    public class GetAppointmentListQuerryHandler : IRequestHandler<GetAppointmentListQuerry, ResponseModel>
    {
        private readonly IUserService _userService;

        public GetAppointmentListQuerryHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(GetAppointmentListQuerry request, CancellationToken cancellationToken)
        {
            return await _userService.GetAppointment(request);


        }
    }
}
