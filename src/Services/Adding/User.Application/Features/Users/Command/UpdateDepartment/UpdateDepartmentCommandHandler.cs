using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public UpdateDepartmentCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateDepartment(request);
        }
    }
}
