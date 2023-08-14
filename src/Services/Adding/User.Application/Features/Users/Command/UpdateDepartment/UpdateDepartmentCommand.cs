using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }
    }
}
