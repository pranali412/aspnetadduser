using MediatR;
using User.Application.Services;

namespace User.Application.Features.Users.Queries.GetDrDropdownlist
{
    public class GetDrDropdownlistQuerryHandler : IRequestHandler<GetDrDropdownlistQuerry, ResponseModel>
    {
        private readonly IUserService _userService;

        public GetDrDropdownlistQuerryHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(GetDrDropdownlistQuerry request, CancellationToken cancellationToken)
        {
            return await _userService.GetDoctorList(request);
        }
    }
}
