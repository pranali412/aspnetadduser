using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.InserRole
{
    public class InsertRoleCommandHandler : IRequestHandler<InsertRoleCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public InsertRoleCommandHandler(IUserService userService)
        {
            this._userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        public async Task<ResponseModel> Handle(InsertRoleCommand request, CancellationToken cancellationToken)
        {
            {
                ResponseModel response = new();
                try
                {
                    return await _userService.InsertRoles(request);
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
