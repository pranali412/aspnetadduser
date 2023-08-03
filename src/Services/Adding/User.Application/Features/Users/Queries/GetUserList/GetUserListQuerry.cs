using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuerry : IRequest<ResponseModel>
    {
        public int Id { get; set; }

    }
}