using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.DeleteRole
{
    public class DeleteRoleCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }

}
