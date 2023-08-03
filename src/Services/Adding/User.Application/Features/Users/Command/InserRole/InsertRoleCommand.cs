using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.InserRole
{
    public class InsertRoleCommand : IRequest<ResponseModel>
    {

        public string RoleName { get; set; }
    }
}
