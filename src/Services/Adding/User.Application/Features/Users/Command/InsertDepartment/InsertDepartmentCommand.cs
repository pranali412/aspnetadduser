using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.InsertDepartment
{
    public class InsertDepartmentCommand : IRequest<ResponseModel>
    {
        public string DepartmentName { get; set; }
    }
}
