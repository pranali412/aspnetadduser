using Microsoft.EntityFrameworkCore;

namespace User.Application.Services
{
    public class UserService : IUserService
    {

        private readonly Infrastructure.Repository.IAsyncRepository<Userr> _userAsyncRepository;
        private readonly Infrastructure.Repository.IAsyncRepository<Role> _roleAsyncRepository;
        private readonly Infrastructure.Repository.IAsyncRepository<Appointment> _appointmentAsyncRepository;
        private readonly Infrastructure.Repository.IAsyncRepository<Department> _deptAsyncRepository;
        private readonly ASPUserDbContext _userDbContext;

        public UserService(Infrastructure.Repository.IAsyncRepository<Userr> userAsyncRepository, Infrastructure.Repository.IAsyncRepository<Appointment> appointmentAsyncRepository, Infrastructure.Repository.IAsyncRepository<Department> deptAsyncRepository, ASPUserDbContext userDbContext, Infrastructure.Repository.IAsyncRepository<Role> roleAsyncRepository)
        {
            _userAsyncRepository = userAsyncRepository ?? throw new ArgumentNullException(nameof(userAsyncRepository));
            _roleAsyncRepository = roleAsyncRepository ?? throw new ArgumentNullException(nameof(roleAsyncRepository));
            _appointmentAsyncRepository = appointmentAsyncRepository ?? throw new ArgumentNullException(nameof(appointmentAsyncRepository));
            _deptAsyncRepository = deptAsyncRepository ?? throw new ArgumentNullException(nameof(deptAsyncRepository));
            _userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
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
                var data = _userDbContext.Users.Where(x => x.FirstName == request.FirstName && x.LastName == request.LastName).Select(y => y).ToList();
                if (data.Count != 0)
                {
                    response.IsSuccess = false;
                    response.Message = "This name is already registered";
                    return response;
                }
                if (request.RoleId == null)
                {
                    response.IsSuccess = false;
                    response.Message = "RoleId is required.";
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
                    throw new Exception("Role not Inserted.");
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
                //    Role Data = null;
                //    if (request.Id == 0)           
                //    {
                //        Data = new();
                //    }
                //    else
                //    {
                //        Data = await _roleAsyncRepository.GetByIdAsync(request.Id);
                //    }

                //    Data.RoleName = request.RoleName;

                //    if (request.Id == 0)
                //    {
                //        Data.CreatedDate = DateTime.UtcNow;
                //        await _roleAsyncRepository.AddAsync(Data);
                //        response.IsSuccess = true;
                //        response.Response = Data;
                //        response.Message = "Role Created.";
                //    }
                //    else
                //    {
                //        Data.LastModifiedDate = DateTime.UtcNow;
                //        await _roleAsyncRepository.UpdateAsync(Data);
                //        response.IsSuccess = true;
                //        response.Response = Data;
                //        response.Message = "Role Updated.";
                //    }
                //}

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

            }

            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return response;
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

        public async Task<ResponseModel> InsertAppointment(InsertAppointmentCommand request)
        {
            ResponseModel response = new();
            try
            {
                var data = _userDbContext.Appointments.Where(x => x.FirstName == request.FirstName && x.LastName == request.LastName).Select(y => y).ToList();
                if (data.Count != 0)
                {
                    response.IsSuccess = false;
                    response.Message = "This name is already registered";
                    return response;
                }
                Appointment appointmentData = new Appointment();


                {
                    appointmentData.FirstName = request.FirstName;
                    appointmentData.LastName = request.LastName;
                    appointmentData.DOB = request.DOB;
                    appointmentData.Gender = request.Gender;
                    appointmentData.Height = request.Height;
                    appointmentData.Weight = request.Weight;
                    appointmentData.EMailId = request.EMailId;
                    appointmentData.ContactNo = request.ContactNo;
                    appointmentData.DepartmentId = request.DepartmentId;
                    appointmentData.AssignDoctor = request.AssignDoctorId;
                    appointmentData.AppointmentDate = request.AppointmentDate;
                    appointmentData.AppointmentTime = request.AppointmentTime;

                }
                var InsertedAppointment = await _appointmentAsyncRepository.AddAsync(appointmentData);
                if (InsertedAppointment == null)
                {
                    throw new Exception("User not Inserted.");

                }
                response.IsSuccess = true;
                response.Message = "Inserted Role Successfully.";
                response.Response = InsertedAppointment;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel> UpdateAppointment(UpdateAppointmentCommand request)
        {
            ResponseModel response = new();
            try
            {
                var appointmentUpdated = await _appointmentAsyncRepository.GetByIdAsync(request.Id);
                appointmentUpdated.FirstName = request.FirstName;
                appointmentUpdated.LastName = request.LastName;
                appointmentUpdated.DOB = request.DOB;
                appointmentUpdated.Gender = request.Gender;
                appointmentUpdated.Height = request.Height;
                appointmentUpdated.Weight = request.Weight;
                appointmentUpdated.EMailId = request.EMailId;
                appointmentUpdated.ContactNo = request.ContactNo;
                appointmentUpdated.DepartmentId = request.DepartmentId;
                appointmentUpdated.AssignDoctor = request.AssignDoctorId;
                appointmentUpdated.AppointmentDate = request.AppointmentDate;
                appointmentUpdated.AppointmentTime = request.AppointmentTime;

                await _appointmentAsyncRepository.UpdateAsync(appointmentUpdated);

                if (appointmentUpdated == null)
                {
                    throw new Exception("User not Updated.");
                }
                response.IsSuccess = true;
                response.Message = "User Role Updated Successfully.";
                response.Response = appointmentUpdated;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel> DeleteAppointment(DeleteAppointmentCommand request)
        {
            ResponseModel response = new();
            try
            {
                var AppointmentToDelete = await _appointmentAsyncRepository.GetByIdAsync(request.Id);
                if (AppointmentToDelete == null)
                {
                    throw new Exception("Failed to Delete");
                }
                await _appointmentAsyncRepository.DeleteAsync(AppointmentToDelete);
                response.IsSuccess = true;
                response.Message = "User Deleted Successfully.";
                response.Response = AppointmentToDelete;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel> GetAppointment(GetAppointmentListQuerry request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var AppointmentList = await _appointmentAsyncRepository.GetByIdAsync(request.Id);

                if (AppointmentList == null)
                {
                    throw new Exception("No record Found");
                }
                response.Response = AppointmentList;
                response.IsSuccess = true;
                response.Message = "Success";


            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel> InsertDepartment(InsertDepartmentCommand request)
        {
            ResponseModel response = new ResponseModel();
            try
            {


                var data = _userDbContext.Departments.Where(x => x.DepartmentName == request.DepartmentName).Select(y => y).ToList();
                if (data.Count != 0)
                {
                    response.IsSuccess = false;
                    response.Message = "This Department is already registered";
                    return response;
                }

                Department deptInsert = new()
                {
                    DepartmentName = request.DepartmentName
                };

                var newInsertDept = await _deptAsyncRepository.AddAsync(deptInsert);
                if (newInsertDept == null)
                {
                    throw new Exception("Department not Inserted.");
                }
                response.IsSuccess = true;
                response.Message = "Department Inserted Successfully.";
                response.Response = newInsertDept;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ResponseModel> UpdateDepartment(UpdateDepartmentCommand request)
        {
            ResponseModel response = new();

            try
            {
                var data = _userDbContext.Departments.Where(x => x.DepartmentName == request.DepartmentName).Select(y => y).ToList();
                if (data.Count != 0)
                {
                    response.IsSuccess = false;
                    response.Message = "This Department is already registered";
                    return response;
                }


                var DeptToUpdate = await _deptAsyncRepository.GetByIdAsync(request.Id);

                DeptToUpdate.DepartmentName = request.DepartmentName;

                await _deptAsyncRepository.UpdateAsync(DeptToUpdate);

                if (DeptToUpdate == null)
                {
                    throw new Exception("dept not updated.");
                }
                response.IsSuccess = true;
                response.Message = "Dept Updated Successfully.";
                response.Response = DeptToUpdate;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }


        public async Task<ResponseModel> DeleteDepartment(DeleteDepartmentCommand request)
        {
            ResponseModel response = new();
            try
            {
                var DeptToDelete = await _deptAsyncRepository.GetByIdAsync(request.Id);
                if (DeptToDelete == null)
                {
                    throw new Exception("Failed to Delete");
                }
                await _deptAsyncRepository.DeleteAsync(DeptToDelete);
                response.IsSuccess = true;
                response.Message = "Department Deleted Successfully.";
                response.Response = DeptToDelete;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponseModel> GetDoctorList(GetDrDropdownlistQuerry request)
        {
            ResponseModel response = new ResponseModel();
            try
            {

                var querry = @"exec[dbo].[sp_getDoctorDropDownList] @Page='" + request.Page + "'," +
                                                                    "@GetAll = '" + request.GetAll + "'," +
                                                                    "@PageSize = '" + request.PageSize + "'";

                var data = await _userDbContext.doctorDropdownVms.FromSqlRaw(querry)!.ToListAsync();
                //return data.ToList();
                response.Response = data.ToList();
                response.IsSuccess = true;
                return response;
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













