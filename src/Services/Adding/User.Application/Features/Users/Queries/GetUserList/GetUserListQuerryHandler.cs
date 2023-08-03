using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuerryHandler : IRequestHandler<GetUserListQuerry, ResponseModel>
    {
        private readonly IUserService _userService;

        public GetUserListQuerryHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(GetUserListQuerry request, CancellationToken cancellationToken)
        {
            return await _userService.GetUsers(request);

        }
    }
}
