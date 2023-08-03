using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.InsertUser
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public InsertUserCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            ResponseModel response = new();
            try
            {
                return await _userService.InsertUsers(request);
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
