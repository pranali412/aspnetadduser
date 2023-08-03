using User.Application.Contracts.Persistence;
using User.Application.Features.Users.Command.DeleteRole;
using User.Application.Features.Users.Command.DeleteUser;
using User.Application.Features.Users.Command.InserRole;
using User.Application.Features.Users.Command.InsertUser;
using User.Application.Features.Users.Command.UpdateRole;
using User.Application.Features.Users.Command.UpdateUser;
using User.Application.Features.Users.Queries.GetUserList;
using User.Domain.Entities;
using User.Domain.ViewModel;

namespace User.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IAsyncRepository<Userr> _userAsyncRepository;
        private readonly IAsyncRepository<Role> _roleAsyncRepository;

        public UserService(IAsyncRepository<Userr> userAsyncRepository, IAsyncRepository<Role> roleAsyncRepository)
        {
            _userAsyncRepository = userAsyncRepository ?? throw new ArgumentNullException(nameof(userAsyncRepository));
            _roleAsyncRepository = roleAsyncRepository;
        }



        public async Task<ResponseModel> InsertUsers(InsertUserCommand request)
        {
            ResponseModel response = new();
            try
            {
                if (request.Password != request.ConfirmPassword)
                {
                    response.IsSuccess = false;
                    response.Message = "Password and Confirm Password Didn't match.";
                    return response;
                }


                Userr userData = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Password = request.Password,
                    ConfirmPassword = request.ConfirmPassword,
                    EmailAddress = request.EmailAddress,
                    EmergencyContactName = request.EmergencyContactName,
                    Title = request.Title,
                    Location = request.Location,
                    MobilePhoneNumber = request.MobilePhoneNumber,
                    EmergencyContactNumber = request.EmergencyContactNumber,
                    OfficePhoneNumber = request.OfficePhoneNumber,
                    Ext = request.Ext,
                    DirectPhoneNumber = request.DirectPhoneNumber,
                    PurchaseBogie = request.PurchaseBogie,
                    SalesBogie = request.SalesBogie,
                    RoleId = request.RoleId,
                };
                var newUser = await _userAsyncRepository.AddAsync(userData);
                if (newUser == null)
                {
                    throw new Exception("failed to create user.");
                }

                response.IsSuccess = true;
                response.Message = "User Inserted Successfully.";
                response.Response = newUser;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel> UpdateUsers(UpdateUserCommand request)
        {
            ResponseModel response = new();
            try
            {
                var UserListToUpdate = await _userAsyncRepository.GetByIdAsync(request.Id);

                UserListToUpdate.FirstName = request.FirstName;
                UserListToUpdate.LastName = request.LastName;
                UserListToUpdate.Password = request.Password;
                UserListToUpdate.ConfirmPassword = request.ConfirmPassword;
                UserListToUpdate.EmailAddress = request.EmailAddress;
                UserListToUpdate.EmergencyContactName = request.EmergencyContactName;
                UserListToUpdate.Title = request.Title;
                UserListToUpdate.Location = request.Location;
                UserListToUpdate.MobilePhoneNumber = request.MobilePhoneNumber;
                UserListToUpdate.EmergencyContactNumber = request.EmergencyContactNumber;
                UserListToUpdate.OfficePhoneNumber = request.OfficePhoneNumber;
                UserListToUpdate.Ext = request.Ext;
                UserListToUpdate.DirectPhoneNumber = request.DirectPhoneNumber;
                UserListToUpdate.PurchaseBogie = request.PurchaseBogie;
                UserListToUpdate.SalesBogie = request.SalesBogie;
                UserListToUpdate.RoleId = request.RoleId;

                await _userAsyncRepository.UpdateAsync(UserListToUpdate);

                if (UserListToUpdate == null)
                {
                    throw new Exception("User not found.");
                }
                response.IsSuccess = true;
                response.Message = "User Inserted Successfully.";
                response.Response = UserListToUpdate;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }


        public async Task<ResponseModel> DeleteUsers(DeleteUserCommand request)
        {
            ResponseModel response = new();

            try
            {
                var userToDelete = await _userAsyncRepository.GetByIdAsync(request.Id);
                if (userToDelete == null)
                {
                    throw new Exception(nameof(Userr));

                }

                await _userAsyncRepository.DeleteAsync(userToDelete);

                response.IsSuccess = true;
                response.Message = "User Deleted Successfully.";
                response.Response = userToDelete;

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ResponseModel> InsertRoles(InsertRoleCommand request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Role userDataRoles = new()
                {
                    RoleName = request.RoleName,

                };
                var newInsertRole = await _roleAsyncRepository.AddAsync(userDataRoles);
                if (newInsertRole == null)
                {
                    throw new Exception("User not found.");
                }
                response.IsSuccess = true;
                response.Message = "Inserted Role Successfully.";
                response.Response = newInsertRole;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ResponseModel> UpdateRoles(UpdateRoleCommand request)
        {
            ResponseModel response = new();

            try
            {

                var UserRoleToUpdate = await _roleAsyncRepository.GetByIdAsync(request.Id);

                UserRoleToUpdate.RoleName = request.RoleName;


                await _roleAsyncRepository.UpdateAsync(UserRoleToUpdate);

                if (UserRoleToUpdate == null)
                {
                    throw new Exception("User not found.");
                }
                response.IsSuccess = true;
                response.Message = "User Role Updated Successfully.";
                response.Response = UserRoleToUpdate;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public async Task<ResponseModel> GetUsers(GetUserListQuerry request)
        {
            ResponseModel response = new();
            try
            {
                var UserList = await _userAsyncRepository.GetByIdAsync(request.Id);
                if (UserList == null)
                {
                    response.Message = "No record found";
                }

                response.Response = UserList;
                response.IsSuccess = true;
                response.Message = "Success";
                return response;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<ResponseModel> DeleteRoles(DeleteRoleCommand request)
        {
            ResponseModel response = new();
            try
            {
                var RolesToDelete = await _roleAsyncRepository.GetByIdAsync(request.Id);
                if (RolesToDelete == null)
                {
                    throw new Exception("Failed to Delete");
                }
                await _roleAsyncRepository.DeleteAsync(RolesToDelete);
                response.IsSuccess = true;
                response.Message = "User Deleted Successfully.";
                response.Response = RolesToDelete;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}













