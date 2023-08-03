using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.UpdateRole
{
    public class UpdateRoleCommand : IRequest<ResponseModel>
    {
        public string RoleName { get; set; }


        public int Id { get; set; }

    }
}
