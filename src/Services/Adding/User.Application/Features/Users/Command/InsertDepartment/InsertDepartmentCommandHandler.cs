using MediatR;
using User.Application.Services;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.InsertDepartment
{
    internal class InsertDepartmentCommandHandler : IRequestHandler<InsertDepartmentCommand, ResponseModel>
    {
        private readonly IUserService _userService;

        public InsertDepartmentCommandHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<ResponseModel> Handle(InsertDepartmentCommand request, CancellationToken cancellationToken)
        {
            return await _userService.InsertDepartment(request);
        }
    }
}
