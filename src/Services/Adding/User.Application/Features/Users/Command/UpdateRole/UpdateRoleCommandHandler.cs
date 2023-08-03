using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public UpdateRoleCommandHandler(IUserService userService)
        {
            this._userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        public async Task<ResponseModel> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            {
                ResponseModel response = new();
                try
                {
                    return await _userService.UpdateRoles(request);
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = ex.Message;
                }
                return response;
            }
        }
    }
}
