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

        Task<ResponseModel> InsertAppointment(InsertAppointmentCommand request);

        Task<ResponseModel> UpdateAppointment(UpdateAppointmentCommand request);

        Task<ResponseModel> DeleteAppointment(DeleteAppointmentCommand request);

        Task<ResponseModel> GetAppointment(GetAppointmentListQuerry request);

        Task<ResponseModel> InsertDepartment(InsertDepartmentCommand request);

        Task<ResponseModel> UpdateDepartment(UpdateDepartmentCommand request);

        Task<ResponseModel> DeleteDepartment(DeleteDepartmentCommand request);

        Task<ResponseModel> GetDoctorList(GetDrDropdownlistQuerry request);
        // Task<ResponseModel> GetDoctorList();

    }
}
