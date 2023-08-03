using User.Application.Features.Users.Command.DeleteRole;
using User.Application.Features.Users.Command.DeleteUser;
using User.Application.Features.Users.Command.InserRole;
using User.Application.Features.Users.Command.InsertUser;
using User.Application.Features.Users.Command.UpdateRole;
using User.Application.Features.Users.Command.UpdateUser;
using User.Application.Features.Users.Queries.GetUserList;
using User.Domain.ViewModel;

namespace User.Application.Services
{
    public interface IUserService
    {
        Task<ResponseModel> GetUsers(GetUserListQuerry request);

        Task<ResponseModel> InsertUsers(InsertUserCommand request);

        Task<ResponseModel> UpdateUsers(UpdateUserCommand request);

        Task<ResponseModel> DeleteUsers(DeleteUserCommand request);

        Task<ResponseModel> InsertRoles(InsertRoleCommand request);

        Task<ResponseModel> UpdateRoles(UpdateRoleCommand request);

        Task<ResponseModel> DeleteRoles(DeleteRoleCommand request);
    }
}
