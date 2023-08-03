using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, ResponseModel>
    {

        private readonly IUserService _userService;

        public DeleteRoleCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            return await _userService.DeleteRoles(request);
            return response;
        }
    }
}
