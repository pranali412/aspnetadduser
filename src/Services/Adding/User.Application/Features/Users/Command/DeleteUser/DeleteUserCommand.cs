using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
