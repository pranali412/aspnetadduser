using MediatR;
using User.Domain.ViewModel;

namespace User.Application.Features.Users.Queries.GetAppointmentList
{
    public class GetAppointmentListQuerry : IRequest<ResponseModel>
    {
        public int Id { get; set; }
    }
}
