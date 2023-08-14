using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Command.DeleteAppointment
{
    public class DeleteAppointmentCommand : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
