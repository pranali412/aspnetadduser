using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
