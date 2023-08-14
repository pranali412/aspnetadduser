using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public DeleteDepartmentCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _userService.DeleteDepartment(request);
        }
    }
}
