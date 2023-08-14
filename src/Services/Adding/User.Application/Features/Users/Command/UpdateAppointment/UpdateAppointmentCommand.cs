using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.UpdateAppointment
{
    public class UpdateAppointmentCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string EMailId { get; set; }
        public string ContactNo { get; set; }
        public int DepartmentId { get; set; }
        public int AssignDoctorId { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }

    }
}
